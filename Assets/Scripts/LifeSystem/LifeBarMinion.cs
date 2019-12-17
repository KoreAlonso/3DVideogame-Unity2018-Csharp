using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//hereda de AbstractLifeBar. SE ejecuta primero su Start()
public class LifeBarMinion : AbstractLifeBar {

    private void Start()
    {
        base.Start();
        //al inicio se asigna una de las capas aleatorias y se añade en su respectiva lista.
        this.gameObject.layer = randomLayer();
        if (this.gameObject.layer == LayerMask.NameToLayer("Dmg"))
        {
            MinionsType.dmgMinions.Add(this.gameObject);
        }
        else
        {
            MinionsType.healerMinions.Add(this.gameObject);
        }  
    }
   private void Update()
    {
        slider.value = currentLife;
        lifeOut();

    }
    protected override void lifeOut()
    {   
        //cuando llegan al minimo de vida, si no son aliados se convierten en aliados, si son aliados se convierten en healers
        
        if (this.gameObject.layer == LayerMask.NameToLayer("Dmg") && this.currentLife <= minLife || this.gameObject.layer == LayerMask.NameToLayer("Healer") && this.currentLife <= minLife) {
            this.gameObject.layer = LayerMask.NameToLayer("Player");
            this.currentLife = this.maxLife;

            MinionsType.allyMinions.Add(this.gameObject);
            MinionsType.dmgMinions.Remove(this.gameObject);
            MinionsType.healerMinions.Remove(this.gameObject);

        }

        if (this.gameObject.layer == LayerMask.NameToLayer("Player") && this.currentLife <= minLife )
        {  
            this.gameObject.layer = LayerMask.NameToLayer("Healer");
            this.currentLife = this.maxLife;

            MinionsType.healerMinions.Add(this.gameObject);
            MinionsType.allyMinions.Remove(this.gameObject);
        }
        
    }

    //de forma aleatoria se escoje una capa u otra. 
    int randomLayer()
    {
        int randomLayer = Random.value >= 0.5 ? LayerMask.NameToLayer("Dmg") : LayerMask.NameToLayer("Healer");
        Debug.Log(randomLayer);
        
       return  randomLayer;
    } 
}
