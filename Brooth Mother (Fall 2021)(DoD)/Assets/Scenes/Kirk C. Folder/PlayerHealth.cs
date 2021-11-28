using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int hearts = 5;
    public int maxHearts = 5;
    public float startimmunityCooldown;

    private bool immuned;
    private float immunityCooldown;
   [SerializeField] Health hs;

    private void Start()
    {
        hs.DrawHeart(hearts, maxHearts);
        immunityCooldown = startimmunityCooldown;
    }

    private void Update()
    {
        // if (hearts <= 0) SceneManager.LoadScene("GAME OVER");

        if (immuned && immunityCooldown >= 0)
        {
            ImmunityCooldown();
        }
        else
        {
            immuned = false;
            immunityCooldown = startimmunityCooldown;
        }
    }

    public void DamagePlayer(int dmg)
    {
        if (hearts > 0)
        {
            hearts -= dmg;
            hs.DrawHeart(hearts, maxHearts);
        }
        if (hearts == 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void HealPlayer(int dmg)
    {
        if (hearts < maxHearts)
        {
            hearts += dmg;
            hs.DrawHeart(hearts, maxHearts);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Bullet")) && !immuned)
        {
            DamagePlayer(1);
            immuned = true;
        }
    }

    void ImmunityCooldown()
    {
        immunityCooldown -= Time.deltaTime;
    }
}