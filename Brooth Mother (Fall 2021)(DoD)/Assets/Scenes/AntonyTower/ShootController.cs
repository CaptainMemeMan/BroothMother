using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{

    public GameObject projectilePrefab;
    public float ShootDelay;
    
    FollowEnemyInRange followEnemyInRange;
    float shootPause;

    
    // Start is called before the first frame update
    void Start()
    {
        followEnemyInRange = GetComponent<FollowEnemyInRange>();
        shootPause = ShootDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (shootPause > 0.0f) {
            shootPause -= Time.deltaTime;
        }

        if (shootPause <= 0.0 && followEnemyInRange.Target != null) {

            Shoot(followEnemyInRange.Target);

            shootPause = ShootDelay;
        }
    }


    void Shoot(Transform targetTransform) {

        GameObject bullet = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        BulletController bulletController = bullet.GetComponent<BulletController>();
        //bulletController.BulletLifeTime = 3f;
        //bulletController.Force = 3f;
        bulletController.Direction = (targetTransform.position - transform.position).normalized;

    }
}
