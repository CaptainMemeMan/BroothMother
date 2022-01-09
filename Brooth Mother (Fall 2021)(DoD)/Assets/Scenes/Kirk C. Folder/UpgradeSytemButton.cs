using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSytemButton : MonoBehaviour
{
    private bool EisPressed;

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && EisPressed)
        {
           
            Debug.Log("Player IN");
        }
        
    }
    // public Shop ShopCustomer;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EisPressed = true; 
           // Debug.Log("Player IN");
          //  ShopCustomer.Show();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EisPressed = false; 
            Debug.Log("Player Out");
            //ShopCustomer.Hide();
        }
    }


    public void selltower()
    {

    }

    public void upgradespeed()
    {

    }

    public void upgradedamage() { 
    
    }
}
