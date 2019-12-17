using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

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
    float minDashTime = 0;
    public float currentDashTime;
    public float maxDashTime = 0.3f;
    float dashCost = 8.5f;

    void Start()
    {
        samurai = GetComponent<CharacterController>();
        inputs = FindObjectOfType<GetInputs>();
        currentDashTime = minDashTime;
    }

    void Update()
    {
        rotate();
        payDash();
        movement();
    }

    //encargado del movimiento WASD
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

    //encargado de inicializar el dash cuando se pulse space y la energia sea mayor que su costo. Tambien se ejcutara mientras dash se mantenga true.
    bool isDashing = false;
    void payDash()
    {
        if ((Input.GetKeyDown(KeyCode.Space) && EnergyBar.sharedInstance.currentValue > dashCost)  || isDashing == true)
        {
            dash();  
        }
    }

    //encargado del movimiento Dash. Siempre que currentDash sea menor a maxDash. isDashing se mantiene en True.
    void dash()
    { 
        if (timerDash() < maxDashTime)
        {   
            //se encarga de cobrar el costo siempre y cuando el pj se mueva. 
            if (isDashing == false && (inputs.getHorizontal() != 0 || inputs.getVertical() != 0)) {
                EnergyBar.sharedInstance.decrease(dashCost);
            }
            isDashing = true;

            timerDash();
            samuraiDash = new Vector3(inputs.getHorizontal(), 0, inputs.getVertical());
            samuraiDash = transform.TransformDirection(samuraiDash);
            samurai.SimpleMove(samuraiDash * dashVelocity);   
        }
        else
        {   //si llega a maxDash, el movimiento equivale a 0
            samuraiDash = Vector3.zero;
            isDashing = false;
        }
    }

    //encargado de ejecutar y devolver currentDash.  
    float timerDash()
    {
        currentDashTime = currentDashTime + 1 * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && currentDashTime >= maxDashTime)
        {
            currentDashTime = minDashTime;
        }
        return currentDashTime;
    }



}
