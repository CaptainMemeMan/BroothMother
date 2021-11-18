using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Vector3 ShootFromPosition;
    // Start is called before the first frame update
    private void Awake(){
        ShootFromPosition = transform.Find("ShootFromPosition").position;
    }
    // Update is called once per frame
    private void Update(){

    }
}
