using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits_Pannel_Opener : MonoBehaviour
{
    public GameObject Panel;

    public void OpenPanel() 
    {
        if (Panel == null)
        {
            bool isAcitve = Panel.activeSelf;
            Panel.SetActive(!isAcitve);
        }
    }
}
