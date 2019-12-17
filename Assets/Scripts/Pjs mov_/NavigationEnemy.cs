using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationEnemy : MonoBehaviour
{
    NavMeshAgent enemy;
    Transform samuraiTransform;
    public float maxRangeDistance = 50;

    void Awake()
    {
        enemy = GetComponent<NavMeshAgent>();
        samuraiTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        persecute();
    }

    //encargado de mirar y perseguir.
    void persecute()

    {   //destiantion sera el trasnsform del target (minionType se encarga de saber quien es el target) 
        Transform destination = MinionsType.target(this.transform);

        //si la distancia ente este objeto y su target es menor al max, lo mira. 
        if (Vector3.Distance(this.transform.position, destination.position) <= maxRangeDistance)
        {
            enemy.transform.LookAt(destination);

            //si es aliado, persigue al jugador, sino al target.     
            enemy.destination = this.gameObject.layer == LayerMask.NameToLayer("Player") ? samuraiTransform.position : destination.position;
        }
    }
    //encargado de devolver true si estan a rango de disparo. 
    public bool shotRange()
    {
        return Vector3.Distance(this.transform.position, MinionsType.target(this.transform).position) <= enemy.stoppingDistance ;  
    }
  
}




