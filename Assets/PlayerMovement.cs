using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    CharacterController samurai;
    float velocity = 2;
    float dashVelocity = 10;
    float rotateVelocity = 5;

    GetInputs getInputs;
    float horizontalDirection;
    float verticalDirection;

   // float hMovement; 
    //float vMovement;
    Vector3 samuraiMovement;
    Vector3 samuraiDash;

     void Start()
    {
        samurai = GetComponent<CharacterController>();
        getInputs = FindObjectOfType<GetInputs>();
        
        
    }
     void Update()
    {
        

        horizontalDirection = getInputs.getHorizontal();
        verticalDirection = getInputs.getVertical();
        
        rotate();
        
        if (horizontalDirection != 0 || verticalDirection != 0)
        {    
             //hMovement = horizontalDirection * velocity ;
            // vMovement = verticalDirection * velocity ;
            
            samuraiMovement = new Vector3(horizontalDirection, 0, verticalDirection);
            samuraiMovement = transform.TransformDirection(samuraiMovement);

            movement(samuraiMovement * velocity);
        }

        if (Input.GetKey(KeyCode.Space))
            {
                samuraiDash = new Vector3(horizontalDirection, 0,verticalDirection);
                samuraiDash = transform.TransformDirection(samuraiDash);

                movement(samuraiDash * dashVelocity);
               /* hMovement = horizontalDirection * dashVelocity   ;*/
                /*vMovement = verticalDirection * dashVelocity ;*/
                
            }
        
    }

     void movement(Vector3 /*inputSpeed*/ inputDirection)
    {
        samurai.SimpleMove( /*inputSpeed*/ inputDirection);
  
    }

    void rotate()
    {
         transform.Rotate(0, Input.GetAxis("Mouse X") * rotateVelocity, 0);
    }

    void dash()
    {
       
    }
}
