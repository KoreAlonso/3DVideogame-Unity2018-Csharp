using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//barra de energia
public class EnergyBar : MonoBehaviour {

    public float totalValue = 100;
    public float currentValue;

    public float valueIncrease = 0.7f, defaultValueIncrease = 0.7f;

    Slider slider;
    public static EnergyBar sharedInstance;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void Start () {
        slider = this.GetComponent<Slider>();
        sharedInstance = this;

        slider.maxValue = totalValue;
        slider.minValue = 0;
     
        currentValue = totalValue ;
       
	}

	void Update () {

        increase();
      
       
	}
    
    //encargado de recibir un costo.Este se restara al currentValue.
    public float decrease(float cost)
    {   if (currentValue - cost < currentValue )
        {
            currentValue -= cost;
            slider.value = currentValue;      
        }
        
        return currentValue; 
    }

    //encargado de incrementar currentValue (solo si es menor a maxValue)
    float increase()
    {   if (currentValue < totalValue)
        {
            currentValue += valueIncrease * Time.deltaTime;
            slider.value = currentValue;
        }
             
        return currentValue;
    }
}
