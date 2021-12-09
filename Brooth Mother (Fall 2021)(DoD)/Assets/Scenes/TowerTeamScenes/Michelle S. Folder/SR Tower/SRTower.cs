using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Vector3 ShootFromPosition;
    private Transform target;

    [Header("Attributes")]

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";
    public float fireRate = 1f;
    public float fireCountDown = 0f;
    public GameObject bulletPrefab;
    public Transform  firePoint;

    public float range = 10f; //Range for short tower, should it only reach 1 aisle or across map?
    // Start is called before the first frame update

    void Start(){
        InvokeRepeating("UpdateTarget",0f,0.5f); //check for nearby targets

    }
   /* void UpdateTarget(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag();
        float shortestDistance=Mathf.Infinity;
        GameObject nearestEnemy = null;
       /* foreach(GameObject enemy in enemies()){
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance){
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
            if(nearestEnemy != null && shortestDistance <= range){
                target = nearestEnemy.transform;
            }
        }
    }*/
   /*     void Shoot(){
       //test Debug.log("pew");
       Instantiate(bulletPrefab,firePoint.position);
    }
    private void Update(){// Update is called once per frame
    ShootFromPosition = transform.Find("ShootFromPosition").position;
    if(fireCountDown <= 0f)
    {
        Shoot();
        fireCountDown = 1f/fireRate;
    }
    fireCountDown -= Time.deltaTime;
    }*/

    void OnDrawGizmosSelected () //deleted 'selected' to see range all the time
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
