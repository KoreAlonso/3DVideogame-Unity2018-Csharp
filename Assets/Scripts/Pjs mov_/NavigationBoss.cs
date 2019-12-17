using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationBoss : MonoBehaviour
{
   public UnityEngine.AI.NavMeshAgent boss;
   public Vector3 randomDirection;
    Vector3 stopBoss;

    float startCount = 0;
    float currentCount;
    float maxCount = 5;

    public LayerMask player;
    public Transform playerTransf;

    public bool isBossStop = false;

    void Start()
    {
        boss = GetComponent<UnityEngine.AI.NavMeshAgent>();
        randomDirection = new Vector3(Random.Range(0, 100), 0, Random.Range(0, 100));
        playerTransf = GameObject.FindGameObjectWithTag("Player").transform;
        currentCount = startCount;
    }

    void Update()
    {
        bossMovement();   
    }

    //se mueve aleatoriamente. si llega a su punto de destino se ejecuta(pointStop)
    void bossMovement()
    {
        boss.destination = randomDirection; 

        if (boss.transform.position.x == boss.destination.x && boss.transform.position.z == boss.destination.z)
        {
            pointStop();
        }
  
    }

    //Comienza el contador. Si actualmente es menor a maxCount, el boss se queda en la posicion. Si es igual a max, busca una nueva posicion. 
    void pointStop()
    {
        counter();

        if(currentCount < maxCount)
        {
             stopBoss = Vector3.zero;
             boss.destination = stopBoss;            
            isBossStop = true;
        }

        if (currentCount == maxCount)
        {
             randomDirection = new Vector3(Random.Range(0, 100), 0, Random.Range(0, 100)); 
             currentCount = startCount;
            isBossStop = false;
        }         
    }

    //devuelve true si el player esta a rango de disparo.
    public bool isBossHitting()
    {
        Debug.Log("isBosshitting");
        return   Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), 15, player);
        

    }

    void counter()
    { 
        if( currentCount < maxCount)
        {
            currentCount += Time.deltaTime;
           
        }
        else
        {
            currentCount = maxCount;
        }
       
    }
}



