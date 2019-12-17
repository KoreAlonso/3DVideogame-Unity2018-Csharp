using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Obtiene Entradas.
public class GetInputs : MonoBehaviour {

    float horizontal;
    float vertical;
  
    void Update () {

        getInput();  
	}

    void getInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");        
        vertical = Input.GetAxisRaw("Vertical");
    }

    //encargados de devolver la direccion actual
    public float getHorizontal()
    {
        return horizontal;
    }

    public float getVertical()
    {
        return vertical;
    }
}
