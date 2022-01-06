using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shop : MonoBehaviour
{

    Currency money;
    public GameObject sr_tower;
    public GameObject lr_tower;
    public GameObject bomb_tower;
    public GameObject farm_tower;
   


    // Start is called before the first frame update
    public void buy_LR()
    {
       
        if ( money.returngold() >= 70)
        {
            Currency.gold -= 70;
            GetComponentInParent<PlayerMovement>().towercarry(lr_tower);
        }
    }

    public void buy_SR()
    {
        if (money.returngold() >= 50)
        {
            Currency.gold -= 50;
            GetComponentInParent<PlayerMovement>().towercarry(sr_tower);
        }
    }
    public void buy_bomb()
    {
        if (money.returngold() >= 30)
        {
            Currency.gold -= 30;
            GetComponentInParent<PlayerMovement>().towercarry(bomb_tower);
        }
    }

    public void buy_PP()
    {
        if (money.returngold() >= 100)
        {
            Currency.gold -= 100;
            GetComponentInParent<PlayerMovement>().towercarry(farm_tower);
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

}
