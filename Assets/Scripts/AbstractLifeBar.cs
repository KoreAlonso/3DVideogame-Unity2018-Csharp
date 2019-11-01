using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractLifeBar : MonoBehaviour {

    public float maxLife;
    float currentLife;
    float minLife = 0;
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
        if (currentLife - damage > minLife)
        {
            currentLife -= damage;
        }else
        {
            //aqui se acaba el juego,  se acabo su vida. 
            lifeOut();
        }
        slider.value = currentLife;
    }
    protected abstract void lifeOut();
}
