using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombtowerscript : MonoBehaviour
{
    public bool exploding = false;
    public bool menuactive = false;
   // public GameObject menu;
    public float animationseconds = 2000f;
    public int explosionDamage = 10;
    public float explosionRadius = 5;
    private CircleCollider2D CollisionDetector;
    public string targetTag = "enemy";
    Animator boom;

    public void Start()
    {
        CollisionDetector = this.GetComponent<CircleCollider2D>();
        //CollisionDetector.radius = explosionRadius;
        boom = GetComponent<Animator>();
    }

    public void deleteBombTower()
    {
        //toggletime(false);
        
        Destroy(this.gameObject,.6f);
        
    }

    public void Update__() {


        GameObject[] objects =  GameObject.FindGameObjectsWithTag(targetTag);

        foreach (GameObject enemy in objects) { 
        
            BoxCollider2D collider  = enemy.GetComponent<BoxCollider2D>();
            bool touching = CollisionDetector.IsTouching(collider);
            if (touching) {

                //GameObject enemy = collision.collider.gameObject;

                fakeenemymovement damage = enemy.GetComponent<fakeenemymovement>(); // needs to be changed to access the right script

                damage.damage(explosionDamage);

                StartCoroutine(deathSequence());// play animation during this
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("Collision with bomb " + collision.gameObject.name);
        if (collision.gameObject.tag == "enemy" && !exploding) // we can add multiple versions if we need to
        {
            Debug.Log("Collision with enemy is bomb " + collision.gameObject.name);
            exploding = true;

    
            //CircleCollider2D CollisionDetector = this.GetComponent<CircleCollider2D>();
            //CollisionDetector.radius = explosionRadius;

            //GameObject enemy = collision.collider.gameObject;

            // fakeenemymovement damage = enemy.GetComponent<fakeenemymovement>(); // needs to be changed to access the right script

            //damage.damage(explosionDamage);

            StartCoroutine(deathSequence());// play animation during this

        }

      //  if (collision.collider.tag == "Player" && !exploding) // for deleting the tower
      //  {

           // togglemenu();
        //}
    }


    private void damageNearby() {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(targetTag);

        foreach (GameObject enemy in objects)
        {

            Collider2D collider = enemy.GetComponent<Collider2D>();
            bool touching = CollisionDetector.IsTouching(collider);
            if (touching)
            {
                enemy.GetComponent<EnemyPath>().updatehealth(explosionDamage);
            }
        }
    }

   /* public void togglemenu()
    {
        menuactive =!menuactive;
        menu.SetActive(menuactive);
        toggletime(menuactive);
        
       
    }

    public void toggletime(bool onoroff)
    {
        if(onoroff)
        Time.timeScale = 0.0f;
        if(!onoroff)
        Time.timeScale = 1f;
    }*/


    IEnumerator deathSequence()
    {
        yield return new WaitForSeconds(.25f);
        damageNearby();
        Destroy(this.gameObject);
    }

}
