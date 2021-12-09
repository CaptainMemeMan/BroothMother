using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float BulletLifeTime;
    public float Force;
    public Vector3 Direction;
    Vector3 Velocity;

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
}
