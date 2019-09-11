using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//barra de energia
public class EnergyBar : MonoBehaviour {

    float totalValue = 100;
    public float currentValue;

    float valueIncrease = 0.7f;

    Slider slider;

    public static EnergyBar sharedInstance;

	void Start () {

        sharedInstance = this;

        slider = this.GetComponent<Slider>();
        slider.maxValue = totalValue;
        slider.minValue = 0;
     
        currentValue = totalValue ;
	}

	void Update () {

        increase();
	}
    
    public float decrease(float cost)
    {   if (currentValue - cost < currentValue )
        {
            currentValue -= cost;
            slider.value = currentValue;      
        }
        
        return currentValue; 
    }

    float increase()
    {   if (currentValue < totalValue)
        {
            currentValue += valueIncrease * Time.deltaTime;
            slider.value = currentValue;
        }
             
        return currentValue;
    }
}
