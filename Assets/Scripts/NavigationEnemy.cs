using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//poner velocidad. 
//que siempre mire al personaje.
public class NavigationEnemy : MonoBehaviour {

    UnityEngine.AI.NavMeshAgent enemy;

    Vector3 direction;
    public Vector3 maxDistance;
    public float minRangeDistance = 10;
    Transform samuraiPosition;

    void Start()
    {
        enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
        samuraiPosition = GameObject.FindGameObjectWithTag("Player").transform;
        maxDistance = new Vector3(2.5f, 0, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        persecute();
    }


    void persecute()
    {
        direction = enemy.destination;

        if (Vector3.Distance(direction, samuraiPosition.position) > minRangeDistance)
        {
           
            direction = samuraiPosition.position - maxDistance;
           // samuraiPosition.LookAt (direction);
            enemy.destination = direction;
        
        } 
    }
}


   

