using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour {

    float totalValue = 100;
    float currentValue;

    float valueIncrease = 0.04f;

    Slider slider;

	void Start () {
        slider = this.GetComponent<Slider>();
        slider.maxValue = totalValue;
        slider.minValue = 0;
        currentValue = totalValue ;
	}

	void Update () {

        increase();
        Debug.Log(currentValue);
     
	}
    
    float decrease(float cost)
    {   if (currentValue - cost < currentValue )
        {
            currentValue -= cost;        
        }
        else
        {
            currentValue = currentValue ;
        }
        slider.value = currentValue;
        return currentValue; 
    }

    float increase()
    {   if (currentValue < totalValue)
        {
            currentValue += valueIncrease * Time.deltaTime;
            
        }
        else
        {
            currentValue = currentValue ;
        }
        slider.value = currentValue;
             
        return currentValue;
    }
}
