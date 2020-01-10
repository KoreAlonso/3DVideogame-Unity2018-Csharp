using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBarPlayer : AbstractLifeBar {

    float shieldValue = 20;
    float shieldCost = 40;

    protected override void lifeOut(){
        GameManager.sharedInstance.gameOver();
    }
    private void Update()
    {
        if (MoveCamera.sharedInstance.transform.parent == MoveCamera.sharedInstance.target.transform)
        {
            shield();
        }

    }

    //Pulsando Q si tiene mas del 75% de energia, podra sumar vida. Esto tiene un costo de 40 de energia.
    void shield()
    {
        if (EnergyBar.sharedInstance.currentValue >= 75 % EnergyBar.sharedInstance.totalValue && Input.GetKeyDown(KeyCode.Q))
        {
            
            this.currentLife = currentLife + shieldValue;
            slider.value = currentLife;
            EnergyBar.sharedInstance.decrease(shieldCost);     
        }
    }
}
