using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Bullet : MonoBehavior




/*public class Projectile : MonoBehaviour
{  
  private List <GameObject> bullets;
  public static Projectile bulletPoolInstance;

//  [SerializeField]
  private GameObject pooledBullet;
  private bool notEnoughBulletsInPool = true;


  private float moveSpeed;
  private Vector2 moveDirection;
  private Vector3 targetPosition;
  private void Awake(){
    bulletPoolInstance = this;
  }
  private void Setup(Vector3 targetPosition){
    this.targetPosition = targetPosition;
  }
/*    private static void Create(){
        Instantiate(Bullet);
    }*/
    // Start is called before the first frame update

    // Update is called once per frame
   /* void Update()
    {
        Vector3 moveDir = (targetPosition - transform.position).normalized;
        float moveSpeed = 20f;

        transform.position += moveDir * moveSpeed * Time.deltaTime;

        float destroySelfDistance = 1f;
        if(Vector3.Distance(transform.position, targetPosition) < destroySelfDistance){
          Destroy(gameObject);
        }
    }
    public GameObject GetBullet(){
      if(bullets.Count > 0){
        for(int i = 0; i < bullets.Count; i++){
          if(!bullets[i].activeInHierarchy){
            return bullets[i];
          }
        }
      }
      if(notEnoughBulletsInPool){
        GameObject bul = Instantiate(pooledBullet);
        bul.SetActive(false);
        bullets.Add(bul);
        return bul;
      }
      return null;
    }
     private int bulletsAmount = 4; //one for every direction

    private float startAngle = 90f, endAngle = 360f;
    private Vector2 bulletMoveDirection;

    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>();
        InvokeRepeating("Fire",0f,2f); //2 second fire time
    }
    private void Fire(){
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for(int i = 0; i < bulletsAmount + 1; i++){
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) /180f);
            float bulDirY = transform.position.x + Mathf.Cos((angle * Mathf.PI) /180f);

            Vector3 bulMoveVector = new Vector3(bulDirX,bulDirY,0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = bullets.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Projectile>().Set.MoveDirection(bulDir);

            angle+=angleStep;
        }
    }
}*/