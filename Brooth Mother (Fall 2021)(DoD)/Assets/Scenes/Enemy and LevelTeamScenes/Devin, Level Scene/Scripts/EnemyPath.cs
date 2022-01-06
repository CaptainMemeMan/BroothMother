using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [SerializeField]
    private Transform enemy;

    public int health = 5;

    private bool death = false;

    [SerializeField]
    private ParticleSystem explosion;

    private Stack<Vector3Int> path = null;

    [SerializeField]
    private AStar AStar;

    private Vector3 destination;

    private void Awake()
    {
        AStar.Algorithm();

        path = AStar.GetFinalPath();
        //Debug.Log(path.Pop());

        enemy.position = path.Pop();
        destination = enemy.position;
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log(path);
            path = AStar.GetFinalPath();
            Debug.Log(path);
            //Debug.Log(path.Pop());

            enemy.position = path.Pop();
            destination = enemy.position;
        }*/

        if (path != null && death == false)
        {
            MoveEnemy(path);
        }

        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    StartCoroutine(explode());
        //}
    }

    private void MoveEnemy(Stack<Vector3Int> path)
    {
        if(enemy.position == destination && path.Count != 0)
        {
            destination = path.Pop();
            //Debug.Log("Destination " + destination);
        }    

        enemy.position = Vector3.MoveTowards(enemy.position, destination, 0.005f);
        //Debug.Log("Moving towards");
        //Debug.Log(path.Count);
    }

    private IEnumerator explode()
    {
        death = true;
        gameObject.GetComponent<Renderer>().enabled = false;
        explosion.Play();
        GetComponent<DropCurrency>().DropCredit();
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }

    public void updatehealth(int hea) {
        health -= hea;

        if (health <= 0) {
            StartCoroutine(explode());
        }
    }



}
