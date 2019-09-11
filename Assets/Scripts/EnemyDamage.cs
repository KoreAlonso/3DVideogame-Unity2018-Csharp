using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    Transform dmgEnemy;
    RaycastHit hit;
    float lengthRay = 700;


    float currentCount;
    float minCount =0;
    float maxCount =5;

	// Use this for initialization
	void Start () {

        dmgEnemy = GameObject.FindGameObjectWithTag("dmg").GetComponent<Transform>();
       
    }
	
	// Update is called once per frame
	void Update () {
        shoot();
       
    }

    void shoot()
    {
        Debug.DrawRay(dmgEnemy.transform.position, transform.forward, Color.red);

               if( Physics.Raycast(dmgEnemy.transform.position, dmgEnemy.transform.forward, lengthRay))

                {
                    Rigidbody bullet = Instantiate(GameObject.FindGameObjectWithTag("shotDmg").GetComponent<Rigidbody>());
                    bullet.AddForce(dmgEnemy.transform.forward * 6, ForceMode.Impulse);
            
            
                }
    }
}
