using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionsType : MonoBehaviour
{

    public static List<GameObject> dmgMinions = new List<GameObject>(60);
    public static List<GameObject> allyMinions = new List<GameObject>(60);
    public static List<GameObject> healerMinions = new List<GameObject>(60);

    Transform transformAlly;
    Transform transformHealer;
    Transform transformDmg;
    static Transform transformPlayer;

    float minRange = 50;

    Transform nearMinion;

    private void Awake()
    {
        transformPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public static Transform target(Transform minionTransform)
    {
        Transform target = null;
        float minDistance = 10000000;

        if (minionTransform.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (dmgMinions.Count == 0 && healerMinions.Count == 0)
            {
                target = transformPlayer;
            }
            else
            {
                foreach (GameObject minionHealer in healerMinions)
                {
                    if (target == null)
                    {
                        target = minionHealer.transform;
                        minDistance = Vector3.Distance(minionHealer.transform.position, minionTransform.position);
                    }
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
        if (minionTransform.gameObject.layer == LayerMask.NameToLayer("Healer"))
        {
            if (allyMinions.Count == 0) target = transformPlayer;
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
        if (minionTransform.gameObject.layer == LayerMask.NameToLayer("Dmg"))
        {
            target = transformPlayer;
        }
        return target;
    }
}