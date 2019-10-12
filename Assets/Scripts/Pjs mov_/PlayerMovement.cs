using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    CharacterController samurai;
    float velocity = 4;
    float dashVelocity = 25;
    float rotateVelocity = 1;
 

    //Variable para acceder a la Clase GetInputs
    GetInputs inputs;

    //Guardan el movimiento (velocidad * direccion)
    Vector3 samuraiMovement;
    Vector3 samuraiDash;

    //Variables método Timer();
    float currentDashTime;
    float maxDashTime = 0.3f;
    float dashCost = 8.5f;
    void Start()
    {
        //Obtengo instancias
        samurai = GetComponent<CharacterController>();
        inputs = FindObjectOfType<GetInputs>();
    }
     void Update()
    {
        rotate();
        dash();
        movement();
    }


    //encargado del movimiento continuo
    void movement()
    { 
        if (inputs.getHorizontal() != 0 || inputs.getVertical() != 0)
        {  
            //se asignan comandos y dirección. Se cambian los ejes globales por defecto, a los ejes locales del CharacterController
          samuraiMovement = new Vector3(inputs.getHorizontal(), 0, inputs.getVertical());
          samuraiMovement = transform.TransformDirection(samuraiMovement);

            //se llama al método movement (Vector3 * float)
          samurai.SimpleMove(samuraiMovement * velocity);  
        }
    }

    //encargado de rotar al Pj.
    void rotate()
    {
         transform.Rotate(0, Input.GetAxis("Mouse X") * rotateVelocity, 0);
    }

    //encargado del movimiento Dash
   void dash()
    {
        if (Input.GetKeyDown(KeyCode.Space)){ 

            EnergyBar.sharedInstance.decrease(dashCost);
        }
        if (Input.GetKey(KeyCode.Space))
            {
              if(timerDash() < maxDashTime)
              { 
                timerDash();

                samuraiDash = new Vector3(inputs.getHorizontal() , 0, inputs.getVertical() );
                samuraiDash = transform.TransformDirection(samuraiDash);

                samurai.SimpleMove(samuraiDash * dashVelocity);
              }
            else
            {   //equivale a 0
                samuraiDash = Vector3.zero;
            }
        }
   }
    //encargado de ejecutar y devolver el tiempo actual. Primero comprueba si este es mayor al tiempo maximo. Si es asi, lo devuelve a 0 
     float  timerDash()
     {      
        if (Input.GetKeyDown(KeyCode.Space) && currentDashTime >= maxDashTime)
        {
            currentDashTime = 0.0f;
        }

        currentDashTime = currentDashTime + 1 * Time.deltaTime;

        return currentDashTime;
     }
    
    
    
}
