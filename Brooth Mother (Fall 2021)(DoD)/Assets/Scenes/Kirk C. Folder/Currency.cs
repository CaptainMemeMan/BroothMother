using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    public static float gold;
     
    GameObject currencyUI;

    void Start()
    {
        currencyUI = GameObject.Find("Currency");
        gold = 500;   //starting gold 
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
    public void goldReset()
    {
        gold = 500; 
    }


}
