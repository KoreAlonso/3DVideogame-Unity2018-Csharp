using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBar : MonoBehaviour {

    float totalEnergy = 100;
    float currentEnergy;

    float timeIncrease = 0.04f;
    
	// Use this for initialization
	void Start () {

        currentEnergy = totalEnergy ;
	}
	
	void Update () {

        energyIncrease();
        Debug.Log(energyIncrease());
     
	}
    
    float energyDecrease(float energyCost)
    {   if (currentEnergy - energyCost < currentEnergy )
        {
            currentEnergy -= energyCost;
        }
        else
        {
            currentEnergy = currentEnergy;
        }
        return currentEnergy;
    }

    float energyIncrease()
    {   if (currentEnergy < totalEnergy)
        {
            currentEnergy += timeIncrease * Time.deltaTime;
        }
        else
        {
            currentEnergy = currentEnergy;
        }
        
        return currentEnergy;
    }
}
