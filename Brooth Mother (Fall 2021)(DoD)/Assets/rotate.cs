using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{

    public GameObject target;
    public bool place;
    private float speed = 5f; 
    

    public void Update()
    {
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);


       
       

    }
    //public void changpos(float anger)
    //{
    //    transform.RotateAround(target.transform.position, new Vector3(0, 0, 1), anger);

    //}

    void OnTriggerStay2D(Collider2D collision)
    {
        place = true;
    }


   void OnTriggerExit2D(Collider2D collision)
    {
        place = false;
    }

}
