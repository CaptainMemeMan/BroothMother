using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSR : MonoBehaviour
{
    public GameObject SR;
    public BulletSpawner monkey;
    public Bullet bulletdmg; 
    public TMPro.TextMeshProUGUI MAX;
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






    public void sellSRtower()
    {
        Debug.Log("Sell");
        Currency.gold += 50;
        Destroy(SR);
    }

    public void upgradebullet()
    {
        if (monkey.cooldown > 1 && Currency.gold >= 50)
        {
           // monkey.hasSpeedUpgrade = true; 
            monkey.cooldown = monkey.cooldown - 0.5f;
            Debug.Log(monkey.numOfBullets);
            
            Currency.gold -= 50;
        }
        else if (monkey.numOfBullets == 1)
        {
            MAX.GetComponent<TMPro.TextMeshProUGUI>().text = ("Max Upgrade");
        }
    }
    //public void upgradedamage()
    //{
    //    if (bulletdmg.damage <= 3 && Currency.gold >= 50)
    //    {
    //        // monkey.hasSpeedUpgrade = true; 
    //        bulletdmg.damage = bulletdmg.damage + 1;
    //        Debug.Log(bulletdmg.damage);

    //        Currency.gold -= 50;
    //    }
    //    else if (bulletdmg.damage == 3)
    //    {
    //        MAX.GetComponent<TMPro.TextMeshProUGUI>().text = ("Max Upgrade");
    //    }
    //}

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
