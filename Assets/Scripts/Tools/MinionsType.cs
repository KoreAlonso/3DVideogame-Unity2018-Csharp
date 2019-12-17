using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionsType : MonoBehaviour
{
    public static List<GameObject> dmgMinions = new List<GameObject>(60);
    public static List<GameObject> allyMinions = new List<GameObject>(60);
    public static List<GameObject> healerMinions = new List<GameObject>(60);

    static Transform transformPlayer;

    private void Awake()
    {
        transformPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    //encargado de devolver el objetivo. Este varia segun la capa a la que pertenezca el argumento. 
    public static Transform target(Transform minionTransform)
    {
        Transform target = null;
        float minDistance = 10000000;

        //si es Player. (minion aliado)
        if (minionTransform.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (dmgMinions.Count == 0 && healerMinions.Count == 0)
            {
                target = transformPlayer;
            }
            else
            {
                
                foreach (GameObject minionHealer in healerMinions)
                {   //si no hay objetivo, sera un healer. la distancia entre ambos sera minDistance
                    if (target == null)
                    {
                        target = minionHealer.transform;
                        minDistance = Vector3.Distance(minionHealer.transform.position, minionTransform.position);
                    }
                    // si se encuentra un healer mas cerca, sera su nuevo objetivo guardando la nueva distancia.  
                    if (Vector3.Distance(minionHealer.transform.position, minionTransform.position) < minDistance)
                    {
                        target = minionHealer.transform;
                        minDistance = Vector3.Distance(minionHealer.transform.position, minionTransform.position);
                    }
                }
                foreach (GameObject minionDmg in dmgMinions)
                {
                    if (target == null)
                    {
                        target = minionDmg.transform;
                        minDistance = Vector3.Distance(minionDmg.transform.position, minionTransform.position);
                    }
                    if (Vector3.Distance(minionDmg.transform.position, minionTransform.position) < minDistance)
                    {
                        target = minionDmg.transform;
                        minDistance = Vector3.Distance(minionDmg.transform.position, minionTransform.position);
                    }
                }
            }


        }

        //si es Healer
        if (minionTransform.gameObject.layer == LayerMask.NameToLayer("Healer"))
        {   
            //si no hay aliados, persigue al Player.
            if (allyMinions.Count == 0) target = transformPlayer;

            //si hay aliado, persigue al mas cercano. 
            foreach (GameObject minionAlly in allyMinions)
            {
                if (target == null)
                {
                    target = minionAlly.transform;
                    minDistance = Vector3.Distance(minionAlly.transform.position, minionTransform.position);
                }
                if (Vector3.Distance(minionAlly.transform.position, minionTransform.position) < minDistance)
                {
                    target = minionAlly.transform;
                    minDistance = Vector3.Distance(minionAlly.transform.position, minionTransform.position);
                }
            }

        }
         //Si es DMG, persigue al pj
        if (minionTransform.gameObject.layer == LayerMask.NameToLayer("Dmg"))
        {
            target = transformPlayer;
        }
        return target;
    }
}