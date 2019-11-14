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
   // public bool x;
    

    void Start()
    {
        navEnemy = FindObjectOfType<NavigationEnemy>();
        
        pointSpawn = this.transform.Find("PointSpawnBullet");
        forceVectorSpell = new Vector3(0f, 3.3f, 22f);
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
        if ( navEnemy.isMinionHitting().Equals(true) &&  currentCount == minCount)
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

        

 

