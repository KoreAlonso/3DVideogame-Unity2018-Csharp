using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationEnemy : MonoBehaviour
{

     NavMeshAgent enemy;
    Transform samuraiTransform;

    public static NavigationEnemy sharedInstance;

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

    //encargado de la persecucion minion -> pj. 
    /* void persecute()
     {
         destination = enemy.destination;

         if (Vector3.Distance(enemy.transform.position, samuraiTransform.position) < maxRangeDistance && minion.layer == dmg)
         {
             enemy.transform.LookAt(samuraiTransform);
             destination = samuraiTransform.position;
             enemy.destination = destination;
             //falta asignar que tambien mirara a los minion aliados en caso de que los haya.  
         }
     }*/

    void persecute()
    {
        Transform destination = MinionsType.target(this.transform);

        if (Vector3.Distance(enemy.transform.position, destination.position) <= maxRangeDistance)
        {
            enemy.transform.LookAt(destination);
            enemy.destination = this.gameObject.layer == LayerMask.NameToLayer("Player") ? samuraiTransform.position : destination.position;
        }

    }
    /*public void persecute(Transform minionTarget)
    {
       
        //destination = enemy.destination;

        if (Vector3.Distance(enemy.transform.position, minionTarget.position) < maxRangeDistance)
        {
            enemy.transform.LookAt(minionTarget);
            destination = minionTarget.position;
            enemy.destination = destination;
             
        }

    }*/

    public bool shotRange()
    {
        return Vector3.Distance(this.transform.position, MinionsType.target(this.transform).position) <= enemy.stoppingDistance ;
        
   
        
        
    }
  
}




