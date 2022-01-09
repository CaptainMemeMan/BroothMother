using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_trigger : MonoBehaviour
{
    public Shop ShopCustomer;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player IN");
            ShopCustomer.Show();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player Out");
            ShopCustomer.Hide();
        }
    }
}
