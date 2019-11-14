using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationEnemy : MonoBehaviour {

    UnityEngine.AI.NavMeshAgent enemy;

    Vector3 destination;
    public Vector3 maxDistance;
    public float maxRangeDistance = 50;
    Transform samuraiTransform;
    

   public LayerMask player;

    void Start()
    {
        enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
        samuraiTransform = GameObject.FindGameObjectWithTag("Player").transform;
        maxDistance = new Vector3(2.5f, 0, 2.5f);
        player = LayerMask.GetMask("Player");

    }

    void Update()
    {
        persecute();
        isMinionHitting();
        Debug.Log(isMinionHitting());
        
    }

    //encargado de la persecucion minion -> pj. 
    void persecute()
    {   
        destination = enemy.destination;

        if (Vector3.Distance(enemy.transform.position, samuraiTransform.position) < maxRangeDistance)
        {
           
            enemy.transform.LookAt(samuraiTransform);
            destination = samuraiTransform.position;
            
            enemy.destination = destination;
            
        }
    }

    //encargado de detectar al pj. Devuelve si o no. 
    public bool isMinionHitting() 
    {
        return Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), 10, player);  
    }

    //NO BORRAR metodo encargado de devolver si hay un traidor cerca o no. Cambiar layerMask. 
   /* public bool isHitTraitors()
    {
        Debug.DrawRay(this.transform.position, transform.TransformDirection(Vector3.forward * 10), Color.cyan);
        if (Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.one), 10, /*traitors*))
        {

            return true;

        }
        else
        {

            return false;
        }

    }*/

}


   

