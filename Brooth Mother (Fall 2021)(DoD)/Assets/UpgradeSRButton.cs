using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSRButton : MonoBehaviour
{
    private bool EisPressed;
    public UpgradeSR fornite;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && EisPressed)
        {
            fornite.Show();

            Debug.Log("Player IN");
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EisPressed = true;
            // Debug.Log("Player IN");

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EisPressed = false;
            Debug.Log("Player Out");
            fornite.Hide();
        }
    }
}
