using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [SerializeField]
    private Transform enemy;

    private Stack<Vector3Int> path = null;

    [SerializeField]
    private AStar AStar = new AStar();

    private Vector3 destination;

    private void Awake()
    {
        path = AStar.GetFinalPath();

        enemy.position = path.Pop();
        destination = enemy.position;
        //Debug.Log(path.Pop());
    }

    void Update()
    {
        if (path != null)
        {
            MoveEnemy(path);
        }
    }

    private void MoveEnemy(Stack<Vector3Int> path)
    {
        if(enemy.position == destination && path.Count != 0)
        {
            destination = path.Pop();
            Debug.Log("Destination " + destination);
        }    

        enemy.position = Vector3.MoveTowards(enemy.position, destination, 0.005f);
        Debug.Log("Moving towards");
        //Debug.Log(path.Count);
    }
}
