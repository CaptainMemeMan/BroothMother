using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Kirk C. 
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f; //the float 

    public Rigidbody2D rb; //access rigidbody in order to make the player move
    
   private Vector2 movement; //stores x and y 
    private float timeStamp = 1f;
    public float cooldownperiod = 1f; 

    private bool Dashing; 
    public void Update()
    {
       movement.x = Input.GetAxisRaw("Horizontal"); //gives us the x value 
       movement.y = Input.GetAxisRaw("Vertical");  // gives us the y value
        
        if (timeStamp <= Time.time) //attach a cooldown timer for the dash 
        {
            
            if (Input.GetKeyDown(KeyCode.LeftShift)) //allows the player to dash 
            {
                Dashing = true;
                timeStamp = Time.time + cooldownperiod;
            }
        }
        
    }

    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.deltaTime); //move the player a new postion 
        
        if (Dashing)
        {
            float dashAmount = 1f;
            rb.MovePosition(rb.position + movement * dashAmount); //allows the player to dash by having its postion add the movemnt * dash power
            Dashing = false;
        } 
    }

   
   
}
