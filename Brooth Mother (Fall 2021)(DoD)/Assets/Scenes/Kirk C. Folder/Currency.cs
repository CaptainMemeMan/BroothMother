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

    //public static int scoreValue = 0;
    //Text score;      // Start is called before the first frame update     
    //void Start()
    //{
    //    score = GetComponent<Text>();
    //}
    //// Update is called once per frame     
    //void Update()
    //{
    //    score.text = scoreValue.ToString();
    //}
}
