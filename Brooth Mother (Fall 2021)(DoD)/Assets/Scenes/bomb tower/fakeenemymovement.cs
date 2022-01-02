using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fakeenemymovement : MonoBehaviour
{
    public float health = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void damage(float damagePoints) {
        health -= damagePoints;

        if (health <= 0f) {
            Destroy(gameObject);
        }
        
    }
}
