using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shop : MonoBehaviour
{

    public GameObject sr_tower;
    public GameObject lr_tower;
    public GameObject bomb_tower;
    public GameObject farm_tower;
    

    public void Start()
    {
       
    }

    // Start is called before the first frame update
    public void buy_LR()
    {
        if (Curreny.gold  >= 70)
        {
            GetComponentInParent<PlayerMovement>().towercarry(lr_tower);
        }
    }

    public void buy_SR()
    {
        if (Curreny.gold >= 50)
        {
            GetComponentInParent<PlayerMovement>().towercarry(sr_tower);
        }
    }
    public void buy_bomb()
    {
        if (Curreny.gold >= 30)
        {
            GetComponentInParent<PlayerMovement>().towercarry(bomb_tower);
        }
    }

    public void buy_PP()
    {
        if (Curreny.gold >= 100)
        {
            GetComponentInParent<PlayerMovement>().towercarry(farm_tower);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
