﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BossSpawn : MonoBehaviour {

    float minCount = 0, currentCount, maxCount = 6;
    Transform pointSpawn;
    public NavMeshAgent minion;
    GameObject minionInstance;
    NavigationBoss navBoss;
    
    
	void Start () {
    

        currentCount = minCount;
        pointSpawn = this.transform;
        navBoss = FindObjectOfType<NavigationBoss>();
	}
	
	// Update is called once per frame
	void Update () {
      
        counterSpawn();
        spawn();
	}

    void spawn()
    {
        if (currentCount >= maxCount && navBoss.isBossStop == false)
        {
            minionInstance = Instantiate(minion.gameObject, this.transform.position, minion.transform.rotation);
            //minionInstance.GetComponent<EnemyShot>().x = true;
        }
    }

    void counterSpawn()
    {
        
        if (currentCount <= maxCount)
        {
            currentCount += Time.deltaTime;

        }
        else
        {
            currentCount = minCount;
        }
    }
}
