using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombtowerscript : MonoBehaviour
{
    public bool exploding = false;
    public bool menuactive = false;
    public GameObject menu;
    public float animationseconds = 2000f;
    public float explosionDamage = 2;
    public float explosionRadius = 5;

    public void deleteBombTower()
    {
        toggletime(false);

        Destroy(this.gameObject);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "enemy") // we can add multiple versions if we need to
        {
            exploding = true;

           CircleCollider2D CollisionDetector = this.GetComponent(typeof(CircleCollider2D)) as CircleCollider2D;
            CollisionDetector.radius = explosionRadius;

            GameObject enemy = collision.collider.gameObject;

            fakeenemymovement damage = enemy.GetComponent<fakeenemymovement>(); // needs to be changed to access the right script

            damage.health = damage.health - explosionDamage;

             StartCoroutine(deathSequence());// play animation during this

        }

        if (collision.collider.tag == "Player" && !exploding) // for deleting the tower
        {

            togglemenu();
        }
    }

    public void togglemenu()
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
    }


    IEnumerator deathSequence()
    {
        yield return new WaitForSeconds(.25f);
    
        Destroy(this.gameObject);
    }

}
