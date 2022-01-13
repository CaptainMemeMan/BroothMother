using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Vector2 velocity;
    public float speed;
    public float rotation;
    public int damage;
    PlayerHealth player; 
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0,0,rotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * speed * Time.deltaTime);
    }


     void OnTriggerEnter2D(Collider2D collision)
      {


        if (collision.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
            collision.GetComponent<EnemyPath>().updatehealth(damage);
        
        }else if (collision.gameObject.layer == 11)
        {
            Destroy(gameObject); 
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
        if (collision.gameObject.CompareTag( "Player"))
        {
            Destroy(gameObject); 
        }
    }

}
