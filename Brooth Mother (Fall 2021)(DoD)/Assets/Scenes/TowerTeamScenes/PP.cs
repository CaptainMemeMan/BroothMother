using System.Collections;
using System.Collections.Generic;
using UnityEngine; //callout PP

public class PP : MonoBehaviour
{   private float startTime;
    public float points = 10; //Variable for the monies
    float t;
    float sec;
    private float timeStamp = 1f;
    public float cooldownperiod = 10f;
    GameObject dollar;
    // Start is called before the first frame update
    void Start()
    {   //points = 0;
            dollar = transform.Find("dollar").gameObject;
        t =0;
        //startTime = Time.deltaTime; Callout Time; (Not nessesary)
    }

    //Update is called once per frame
    void Update()
    {
        t += Time.deltaTime; // - startTime;
                             //displaySeconds= seconds % 60;
                             //sec = (t % 60);

        if (timeStamp <= Time.time) //attach a cooldown timer for the dash 
        {
            dollar.SetActive(true);
            Currency.gold = Currency.gold + points;
            //t = 0;
            //points = 0;
            timeStamp = Time.time + cooldownperiod;
            Debug.Log("Added" + Currency.gold);

        }

        //if (t % 5 <= 0.003)  {     //Percent sign means we are getting the remainder
        //    Currency.gold = points + 10;
        //    t = 0;
        //    points = 0; 
        //}
   // Debug.Log("Points " + Currency.gold);
   
    }

    
}   
