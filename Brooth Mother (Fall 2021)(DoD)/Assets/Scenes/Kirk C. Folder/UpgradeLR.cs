using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeLR : MonoBehaviour
{
    public GameObject LR;
    public ShootController bulletspeed;
    //public BulletController bulletdmg; 
    private void Start()
    {
        Hide();
        //bulletspeed.GetComponent<ShootController>();
        //bulletdmg.GetComponent<BulletController>(); 
        
    }


    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }






    public void sellLRtower()
    {
        Debug.Log("Sell");
        Currency.gold += 50;
        Destroy(LR); 
    }

    public void upgradespeed()
    {
        if (bulletspeed.ShootDelay > 1 && Currency.gold >= 50)
        {
            bulletspeed.ShootDelay = bulletspeed.ShootDelay - 0.25f;
            Currency.gold -= 50;
        }
    }

    //public void upgradedamage()
    //{
    //    if (bulletdmg.damage < 7)
    //    {
    //        bulletdmg.damage = bulletdmg.damage + 1;
    //        Currency.gold -= 50;
    //        Debug.Log(bulletdmg.damage);  
    //    }
    //}
}
