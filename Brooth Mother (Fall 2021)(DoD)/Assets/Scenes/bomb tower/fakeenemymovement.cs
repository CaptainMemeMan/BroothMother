using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fakeenemymovement : MonoBehaviour
{
    public float health = 10;
    public float moveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        }
    }

   /* private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Whole bomb tower")
        {
            health = health - 1;

            GameObject bomb = GameObject.Find("Whole bomb tower");

            bombtowerscript damage = bomb.GetComponent<bombtowerscript>();

            damage.explosionDamage = 0;
        }
    }*/

}
