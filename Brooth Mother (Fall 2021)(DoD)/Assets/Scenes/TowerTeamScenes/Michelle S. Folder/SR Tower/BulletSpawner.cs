using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Michelle S.
//Prints short range tower rotations in a bullet-hell style
//base set to 4 bullets(up/down/left/right) in even rotations
public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletResource;
    public float minRotation;
    public float maxRotation;
    public int numOfBullets;
    public bool isRandom;

    public float cooldown;
    float timer;
    public float bulletSpeed;
    public Vector2 bulletVelocity;

    float[] rotations;

    // Start is called before the first frame update
    void Start()
    {
        timer = cooldown;
        rotations = new float[numOfBullets];
        if(!isRandom)
        {
            DistributedRotations();//Since rotations are the same, move to update if you change min/max rotation
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0){
            SpawnBullets();
            timer = cooldown;
        }
        timer -= Time.deltaTime;
        
    }

    //Possible malfunction operation for towers? after a certain amount of time a player
    //must dodge the bullets to repair towers, otherwise delete
    public float[] RandomRotations()
    {
        for(int i = 0; i < numOfBullets; i++){
            rotations[i] = Random.Range(minRotation, maxRotation);
        }
        return rotations;
    }

    public float[] DistributedRotations()
    {
        for (int i = 0; i < numOfBullets; i++){
            var fraction = (float)i / (float)numOfBullets; //subtract 1 since we're counting from 0
            var difference = maxRotation - minRotation;
            var fractionOfDifference = fraction * difference;
            rotations[i] = fractionOfDifference + minRotation; //undo difference
        }
        foreach (var r in rotations) print(r);
        return rotations;
    }

    public GameObject[] SpawnBullets()
    {
        if(isRandom)
        {
            RandomRotations();
        }

        //spawn bullets
        GameObject[] spawnedBullets = new GameObject[numOfBullets];

        for(int i = 0; i < numOfBullets; i++)
        {
            spawnedBullets[i] = Instantiate(bulletResource, transform);
            //BulletManager.bullets.Add(spawnedBullets[i]);   
            var b = spawnedBullets[i].GetComponent<Bullet>();
            b.rotation = rotations[i];
            b.speed = bulletSpeed;
            b.velocity = bulletVelocity;
      }
        return spawnedBullets;
    }

}
