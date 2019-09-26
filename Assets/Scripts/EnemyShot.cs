using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour {

    float maxCount = 3.5f;
    float minCount= 0;
    float currentCount;

    Transform pointSpawn;
    public Rigidbody bullet;
    Rigidbody cloneBullet;

    NavigationEnemy navEnemy;

    void Start() {
        

        navEnemy = FindObjectOfType<NavigationEnemy>();
        pointSpawn = GameObject.FindGameObjectWithTag("PointSpawn").GetComponent<Transform>();
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

        if ( navEnemy.isHitPlayer() /*|| navEnemy.isHitTraitors()*/ == true &&  currentCount == minCount)
        {
            cloneBullet = Instantiate(bullet,pointSpawn.position, rotation);
            cloneBullet.AddForce(transform.TransformDirection(new Vector3(0f ,3.3f,22f) )  , ForceMode.Impulse);
            bullet.GetComponent<MeshRenderer>().enabled = true;
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

        

 

