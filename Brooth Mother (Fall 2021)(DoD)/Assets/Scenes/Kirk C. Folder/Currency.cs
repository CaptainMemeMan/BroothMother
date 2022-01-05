using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    public static float gold = 100;
    GameObject currencyUI;

    void Start()
    {
        currencyUI = GameObject.Find("Currency");

    }
    void Update()
    {
        currencyUI.GetComponent<Text>().text = gold.ToString();

        if (gold < 0)
        {
            gold = 0;
        }
    }

    public float returngold() {


        return gold;
    
    }


}
