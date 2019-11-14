using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractLifeBar : MonoBehaviour {

    public float maxLife;
    public float currentLife;
    protected float minLife = 0;
    float shieldValue = 17;

     public Slider slider;

	void Start () {
        slider.maxValue = maxLife;
        currentLife = maxLife;
        
	}
	
	// Update is called once per frame
	void Update () {

        slider.value = currentLife;
        
	}
    public void decreaseLife( float damage)
    {
       
        if (currentLife - damage >= minLife)
        {
            currentLife -= damage;
        }
        if(currentLife <= minLife)
        {
            lifeOut();
        }
        
        slider.value = currentLife;
    }
    protected abstract void lifeOut();
}
