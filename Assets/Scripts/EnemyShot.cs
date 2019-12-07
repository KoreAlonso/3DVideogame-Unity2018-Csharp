using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : InstantiateShot {

    float maxCount = 3.5f;
    float minCount= 0;
    float currentCount;

    Transform pointSpawn;
    Vector3 forceVectorSpell;
    Rigidbody cloneBullet;

    NavigationEnemy navEnemy;
   
    

    void Start()
    {
        navEnemy = GetComponent<NavigationEnemy>();
        
        pointSpawn = this.transform.Find("PointSpawnBullet");
        forceVectorSpell = new Vector3(0f, -2, 32f);
        currentCount = minCount; 
    }

    void Update()
    {
        
        spellInstanciate();
        counter();
    }

    //añadir la condicion de si se detecta algun personaje traidor. 
    void  spellInstanciate()
    {
     
       if (currentCount == minCount && navEnemy.shotRange() && this.gameObject.layer != MinionsType.target(this.transform).gameObject.layer)
        {
            this.shot(transform.TransformDirection(forceVectorSpell), pointSpawn.position);
        }  

    }
    protected override void setUpShotVariables(){}
 
    float counter()
    {
        if(minCount <= currentCount)
        {
            currentCount += Time.deltaTime;
        }

        if (currentCount >= maxCount)
        {
            if (cloneBullet != null)
            {
                Destroy(cloneBullet.gameObject);
            }

         currentCount = minCount;
        }
        return currentCount;
    }

    
}

        

 

