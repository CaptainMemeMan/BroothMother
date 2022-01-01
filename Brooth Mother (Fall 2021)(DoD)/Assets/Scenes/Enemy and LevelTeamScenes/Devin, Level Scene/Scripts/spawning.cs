using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning : MonoBehaviour
{

    public GameObject enemy;
    // Start is called before the first frame update
    public float timer = 5.0f;

    // Update is called once per frame
    void Update()
    {
        if (timer <= 1)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            timer = 5.0f;
        }
        else {
            timer -= Time.deltaTime;

        }
    }
}
