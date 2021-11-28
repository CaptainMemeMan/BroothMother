using System.Collections;
using System.Collections.Generic;
using UnityEngine; //callout PP

public class PP : MonoBehaviour
{   private float startTime;
    float points; //Variable for the monies
    float t;
    float sec;
    // Start is called before the first frame update
    void Start()
    {   points = 0;
        t=0;
        //startTime = Time.deltaTime; Callout Time; (Not nessesary)
    }

    //Update is called once per frame
    void Update()
    {
        t += Time.deltaTime; // - startTime;
                //displaySeconds= seconds % 60;
        //sec = (t % 60);
        
        if (t % 5 <= 0.003)  {     //Percent sign means we are getting the remainder
        points = points + 10; 
        }
    Debug.Log("Points " + points);
    //Debug.Log("t " + (t % 10));
    }
}   
