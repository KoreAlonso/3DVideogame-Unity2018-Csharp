using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour {

    float maxLife = 100;
    public float currentLife;
    float minLife = -2;
    float shieldValue = 17;

    public static LifeBar sharedInstand;
    Slider slider;

	void Start () {
        slider = this.GetComponent<Slider>();
        currentLife = maxLife;
        sharedInstand = this;
	}
	
	// Update is called once per frame
	void Update () {
        slider.value = currentLife;
        
	}

    public  float decreaseLife( float damage)
    {
        if (currentLife - damage > minLife)
        {
            if (currentLife - damage <= minLife)
            {
                //aqui se acaba el juego,  se acabo su vida. 
            }

            currentLife -= damage * Time.deltaTime;
            slider.value = currentLife;

        }
       
        return currentLife;
        
    }

    void increaseLife()
    {
        //con el item, sube x de vida.
    }

    void extraProtect()
    {
        //con currentenergy, y x tecla, sumar x vida ( funcionara como escudo por tiempo) 
    }
}
