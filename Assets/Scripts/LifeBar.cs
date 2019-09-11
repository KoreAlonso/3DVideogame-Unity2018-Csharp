using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour {

    float maxLife = 100;
    public float currentLife;
    float minLife = -2;
    float shieldValue = 17;

    Slider slider;

	void Start () {
        slider = this.GetComponent<Slider>();
        currentLife = maxLife;
	}
	
	// Update is called once per frame
	void Update () {
        slider.value = currentLife;
	}

    void decreaseLife()
    {
        //con tipo de daño recibido, restar vida. 
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
