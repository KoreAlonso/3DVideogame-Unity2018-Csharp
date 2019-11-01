using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : InstantiateShot {

    float maxCount = 3.5f;
    float minCount= 0;
    float currentCount;

    Transform pointSpawn;
    Rigidbody cloneBullet;

    NavigationEnemy navEnemy;
   // public bool x;
    

    void Start()
    {
        navEnemy = FindObjectOfType<NavigationEnemy>();
        
        pointSpawn = this.transform.Find("PointSpawnBullet");
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
        if ( navEnemy.isMinionHitting() /*|| navEnemy.isHitTraitors()*/ == true &&  currentCount == minCount)
        {
            this.shot();
        }  
    }
    protected override void setUpShotVariables()
        {
            this.shotSpawnPoint = pointSpawn.position;
            this.shotForceVector = transform.TransformDirection(new Vector3(0f, 3.3f, 22f));
            
        }
   

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

        

 

