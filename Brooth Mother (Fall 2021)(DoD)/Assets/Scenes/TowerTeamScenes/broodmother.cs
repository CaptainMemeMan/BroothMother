using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class broodmother : MonoBehaviour
{
    public int totalhealth = 10;


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "enemy") {
            Destroy(collision.gameObject);
            int hea = collision.GetComponent<EnemyPath>().health;
            totalhealth -= hea;
            if (totalhealth <= 0) {
                Destroy(gameObject);
            }
        }

    }

}
