using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shop : MonoBehaviour
{

    Currency money;
    public static float cur = Currency.gold; 
    public GameObject sr_tower;
    public GameObject lr_tower;
    public GameObject bomb_tower;
    public GameObject farm_tower;
    public PlayerHealth health;

    //initialize audio (source is from player)
    public AudioSource audio;

    //define function to play sound when button is clicked
    public void audioTrigger()
    {
        audio.Play();
    }



    public void buy_LR()
    {
       
        if ( Currency.gold >= 70 && !checkcir())
        {
            Currency.gold -= 70;
            //cur -= 70;
            GetComponentInParent<PlayerMovement>().towercarry(lr_tower);
        }
    }

    public void buy_SR()
    {
        if (Currency.gold >= 50 && !checkcir())
        {
            Currency.gold -= 50;
          //  cur -= 50;
            GetComponentInParent<PlayerMovement>().towercarry(sr_tower);
        }
    }
    public void buy_bomb()
    {
        if (Currency.gold >= 30 && !checkcir())
        {
            Currency.gold -= 30;
          //  cur -= 30; 
            GetComponentInParent<PlayerMovement>().towercarry(bomb_tower);
        }
    }

    public void buy_PP()
    {
        if (Currency.gold >= 100 && !checkcir())
        {
            Currency.gold -= 100;
           // cur -= 100;
            GetComponentInParent<PlayerMovement>().towercarry(farm_tower);
        }
    }

    public void buy_Health()
    {
        if (Currency.gold >= 50 && health.hearts != health.maxHearts)
        {
            health.HealPlayer(1);
            Currency.gold -= 50;
        }
       
    }

    private void Start()
    {
        Hide();
    }


    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }


    bool checkcir() {

        return GetComponentInParent<PlayerMovement>().cir.activeSelf;


    }

}
