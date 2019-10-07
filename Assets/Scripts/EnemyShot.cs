using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour {

    float maxCount = 3.5f;
    float minCount= 0;
    float currentCount;

    Transform pointSpawn;
    public Rigidbody spell;
    Rigidbody cloneBullet;

    NavigationEnemy navEnemy;
    

    void Start() {
        

        navEnemy = FindObjectOfType<NavigationEnemy>();
        
        pointSpawn = this.transform.Find("PointSpawnBullet");
        currentCount = minCount; 
    }

    void Update() {

        bulletInstanciate();
        
        counter();
    }

    //añadir la condicion de si se detecta algun personaje traidor. 
    void  bulletInstanciate()
    {
        Quaternion rotation = new Quaternion(0, 0, 0, 0);

        if ( navEnemy.isMinionHitting() /*|| navEnemy.isHitTraitors()*/ == true &&  currentCount == minCount)
        {
            cloneBullet = Instantiate(spell,pointSpawn.position, rotation);
            cloneBullet.AddForce(transform.TransformDirection(new Vector3(0f ,3.3f,22f) )  , ForceMode.Impulse);
            spell.GetComponent<MeshRenderer>().enabled = true;
        }  
      
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

        

 

