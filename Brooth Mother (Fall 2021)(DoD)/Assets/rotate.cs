using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{

    public GameObject target;
    public bool place;


    public void changpos(float anger)
    {
        transform.RotateAround(target.transform.position, new Vector3(0, 0, 1), anger);
    
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        place = true;
    }


   void OnTriggerExit2D(Collider2D collision)
    {
        place = false;
    }

}
