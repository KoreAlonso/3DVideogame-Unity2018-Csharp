using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBar : MonoBehaviour {

    float totalEnergy = 100f;
    float minEnergy;
    float currentEnergy;
    
    
	// Use this for initialization
	void Start () {

        currentEnergy = totalEnergy;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void energyDecrease(float energyCost)
    {
        currentEnergy -= energyCost;
    }
}
