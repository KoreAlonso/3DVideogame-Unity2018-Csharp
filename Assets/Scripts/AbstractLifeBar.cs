using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractLifeBar : MonoBehaviour {

    public float maxLife;
    protected float minLife = 0;
    float shieldValue = 17;

     public Slider slider;
    public float currentLife;

    protected void Start()
    {
        currentLife = maxLife;
        slider.maxValue = maxLife;
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
