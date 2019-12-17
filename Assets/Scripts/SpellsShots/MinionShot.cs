using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//hereda de InstantiateShot.Encargado del disparo de Minions.
public class MinionShot : InstantiateShot {
    //variables contador
    float maxCount = 3.5f;
    float minCount= 0;
    float currentCount;

    //variables disparo
    Transform pointSpawn;
    Vector3 forceVectorSpell;

    NavigationEnemy navEnemy;
 
    void Start()
    {   
        pointSpawn = this.transform.Find("PointSpawnBullet");
        forceVectorSpell = new Vector3(0f, -2, 32f);
        currentCount = minCount;
        navEnemy = GetComponent<NavigationEnemy>();
    }

    void Update()
    {
        spellInstanciate();
        counter();
    }

    //dispara si el contador esta a minCount y esta a rango de un enemigo que no sea de su capa. 
    void  spellInstanciate()
    {
       if (currentCount == minCount && navEnemy.shotRange() && this.gameObject.layer != MinionsType.target(this.transform).gameObject.layer)
        {
            this.shot(transform.TransformDirection(forceVectorSpell), pointSpawn.position);
        }  
    }
    
    //contador.Destruye la "bala" al llegar a maxCount.
    float counter()
    {
        if(minCount <= currentCount)
        {
            currentCount += Time.deltaTime;
        }

        if (currentCount >= maxCount)
        {
            if (cloneShot != null)
            {
                Destroy(cloneShot.gameObject);
            }

         currentCount = minCount;
        }
        return currentCount;
    }

    
}

        

 

