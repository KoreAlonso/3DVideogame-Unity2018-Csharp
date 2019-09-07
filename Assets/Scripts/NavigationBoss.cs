using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationBoss : MonoBehaviour
{

    UnityEngine.AI.NavMeshAgent boss;

    Vector3 randomDirection;

 float startCount = 0;
   float currentCount;
   float maxCount = 5;


    void Start()
    {
        boss = GetComponent<UnityEngine.AI.NavMeshAgent>();
        randomDirection = new Vector3(Random.Range(0, 100), 0, Random.Range(0, 100));
        currentCount = startCount;
    }

    // Update is called once per frame
    void Update()
    {
        bossMovement();
        //counter();
    }

    void bossMovement()
    {
       
        boss.destination = randomDirection;
        //Debug.Log(randomDirection );
        Debug.Log("me muevo");

        if (boss.transform.position.x == boss.destination.x && boss.transform.position.z == boss.destination.z)
        {
            Debug.Log("llamo a point stop");
            pointStop();

        }
        

    }

    void pointStop()
    {
        counter();
        if(currentCount < maxCount)
         {
            Vector3 stopBoss = Vector3.zero;
             boss.destination = stopBoss;
             Debug.Log("estoy en point stop" + currentCount);


        }
        if (currentCount == maxCount)
             {
                 randomDirection = new Vector3(Random.Range(0, 100), 0, Random.Range(0, 100));
                 Debug.Log("point stop, nueva direccion");
                 currentCount = startCount;
             }
        
               
    }
        
   
    void counter()
    { 
        if( currentCount < maxCount)
        {
            currentCount += Time.deltaTime;
            Debug.Log("estoy en counter, tiempo actual = " + currentCount);
        }
        else
        {
            currentCount = maxCount;
        }
       
    }
}



