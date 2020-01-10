using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Encargado del Spawn de minions.
public class BossSpawn : MonoBehaviour {

    float minCount = 0, currentCount, maxCount = 6;

   // Transform pointSpawn;
    public NavMeshAgent minion;
    GameObject minionInstance;

    //maximo de spawn del boss.
    int currentMinions = 0;
    int maxMinions, easyMax = 1, normalMax = 12, hardMax = 12; 

    NavigationBoss navBoss;

	void Start () {
        navBoss = FindObjectOfType<NavigationBoss>();
        currentCount = minCount;
        maxMinions = GameDifficulty.assignDifficulty<int>(easyMax, normalMax, hardMax);
        
	}
	void Update () {   
        counterSpawn();
        spawn();
    }
    void spawn()
    {   //spawnea solo si esta en movimientoy cada x segundo. El numero de minions no puede superar el maximo establecido. 
        if (currentCount >= maxCount && navBoss.isBossStop == false && currentMinions < maxMinions)
        {
            minionInstance = Instantiate(minion.gameObject, this.transform.position, minion.transform.rotation);
            currentMinions++;
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
