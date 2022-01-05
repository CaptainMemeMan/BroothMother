using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float BulletLifeTime;
    public float Force;
    public Vector3 Direction;
    Vector3 Velocity;
    public int damage = 2;

    // Start is called before the first frame update
    void Start()
    {
        Velocity = Direction * Force;
    }

    // Update is called once per frame
    void Update()
    {

        transform.localPosition += Velocity * Time.deltaTime;
        BulletLifeTime -= Time.deltaTime;

        if (BulletLifeTime < 0f) {
            Destroy(gameObject);
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
            collision.GetComponent<EnemyPath>().updatehealth(damage);

        }
        //else if (collision.gameObject.tag == "Player")
        //{
        //    collision.GetComponent<PlayerHealth>().DamagePlayer(1);
        //    Destroy(gameObject);
        //    player.immuned = true; 
        //}
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }



}
