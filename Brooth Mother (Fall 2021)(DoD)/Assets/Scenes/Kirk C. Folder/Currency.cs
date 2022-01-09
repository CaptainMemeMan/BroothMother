using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    public static float gold;

    public TMPro.TextMeshProUGUI currencyUI;

    void Start()
    {
       // currencyUI = GetComponent<TMPro.TextMeshProUGUI>();
        gold = 500;   //starting gold 
    }
    void Update()
    {
        currencyUI.GetComponent<TMPro.TextMeshProUGUI>().text = gold.ToString();

        if (gold < 0)
        {
            gold = 0;
        }
    }

    public float returngold()
    {


        return gold;

    }
    public void goldReset()
    {
        gold = 500;
    }

    
}
