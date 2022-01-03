using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Kirk C. 
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f; //the float 
  GameObject cir;
  public  GameObject tow;

    public Rigidbody2D rb; //access rigidbody in order to make the player move
    
   private Vector2 movement; //stores x and y 
    private float timeStamp = 1f;
    public float cooldownperiod = 1f; 

    private bool Dashing;


    public float addAmount;

    private void Start()
    {
        cir = transform.Find("Circle").gameObject;
    }

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


        if (Input.GetKey("space"))
        {
            towerplacement();
        }

        /*
        if (Input.GetKeyDown("space")) {
            towercarry(tow);
        
        }
        */

    }

    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.deltaTime); //move the player a new postion 
       // cir.GetComponent<rotate>().changpos(Mathf.Atan2(movement.y, movement.x));

        if (Dashing)
        {
            float dashAmount = 1f;
            rb.MovePosition(rb.position + movement * dashAmount); //allows the player to dash by having its postion add the movemnt * dash power
            Dashing = false;
        } 
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        
        if (obj.gameObject.tag == "Money")
        {
            Currency.gold += addAmount;
            Destroy(obj.gameObject);
        }

    }

    void towercarry(GameObject tower) {
        tow = tower;
        cir.GetComponent<SpriteRenderer>().sprite = tow.GetComponent<SpriteRenderer>().sprite;
        cir.SetActive(true);
      

    }



    void towerplacement() {
        if (!cir.GetComponent<rotate>().place && cir.activeSelf) {
            Instantiate(tow, cir.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            cir.SetActive(false);
        }

    }




}
