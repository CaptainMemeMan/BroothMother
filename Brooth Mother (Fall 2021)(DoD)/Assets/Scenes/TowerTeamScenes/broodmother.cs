using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;

public class broodmother : MonoBehaviour
{
    public int totalhealth = 10;
    public int currentHealth;


    public HealthBar healthbar; 
    private void Start()
    {
  
        currentHealth = totalhealth;
        healthbar.SetMaxHealth(totalhealth); 
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "enemy") {
            Destroy(collision.gameObject);
            int hea = collision.GetComponent<EnemyPath>().health;
            currentHealth -= hea;
            Debug.Log("Hit");
            healthbar.SetHealth(currentHealth); 
            if (currentHealth <= 0) {
                SceneManager.LoadScene("GameOver");
                Destroy(gameObject);
            }
        }

    }

}
