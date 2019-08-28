using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour {
    UnityEngine.AI.NavMeshAgent enemy;

    Vector3 direction;
    Transform samuraiPosition;
	// Use this for initialization
	void Start () {
        enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
        samuraiPosition = GameObject.FindGameObjectWithTag("Player").transform;
        direction = enemy.destination;
	}
	
	// Update is called once per frame
	void Update () {
        persecute();
	}
    void persecute()
    {
        if(Vector3.Distance( direction, samuraiPosition.position) > 7)
        {
            direction = samuraiPosition.position;
            enemy.destination = direction;

            if(Vector3.Distance (direction, samuraiPosition.position) == 10)
            {
                direction = enemy.transform.position;
                
            }
           
        }

    }
}
