using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInputs : MonoBehaviour {

    float horizontal;
    float vertical;
  
    void Update () {

        getInput();
        
	}
    void getInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Debug.Log(horizontal + "horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Debug.Log(vertical + "vertical");
        

    }

    public float getHorizontal()
    {
        return horizontal;
    }

    public float getVertical()
    {
        return vertical;
    }
}
