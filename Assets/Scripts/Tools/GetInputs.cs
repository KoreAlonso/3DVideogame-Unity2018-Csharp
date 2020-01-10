using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Obtiene Entradas.
public class GetInputs : MonoBehaviour {

    float horizontal;
    float vertical;
   public static  GetInputs sharedInstance;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        sharedInstance = this;
    }
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
