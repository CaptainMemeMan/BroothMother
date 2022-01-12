using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePP : MonoBehaviour
{
    public GameObject PP;
    public PP poop;
    public TMPro.TextMeshProUGUI MAX;
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




    public void MoreMoney()
    {
        if (Currency.gold >= 50 && poop.points < 40)
        {
            poop.points = poop.points + 5;
            Currency.gold -= 50; 
            Debug.Log(poop.points);
        }else if (poop.points == 40)
        {
            MAX.GetComponent<TMPro.TextMeshProUGUI>().text = ("Max Upgrade");
        }
    }

    public void sellPPtower()
    {
        Debug.Log("Sell");
        Currency.gold += 50;
        Destroy(PP);
    }

   
}
