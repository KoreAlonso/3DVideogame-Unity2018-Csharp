using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractLifeBar : MonoBehaviour {

    public float maxLife;
    protected float minLife = 0;
    public float currentLife;
    public Slider slider;
    
    protected void Start()
    {
        currentLife = maxLife;
        slider.maxValue = maxLife;
    }
    //obtiene el daño y se lo resta. Si currentlife es menor a minLife se ejecuta LifeOut()
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
    //se desarrolla en los scripts que heredan de este
    protected abstract void lifeOut();
}
