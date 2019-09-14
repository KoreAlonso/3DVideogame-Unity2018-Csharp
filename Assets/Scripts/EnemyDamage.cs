using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    Transform dmgEnemy;
    Ray ray;
    NavigationEnemy navigationEnemy;

    float costDamage = 0.1f;
    public LayerMask player;

    Vector3 shootStart;
    Rigidbody bullet;
    Rigidbody cloneBullet;

    void Start() {

        dmgEnemy = GameObject.FindGameObjectWithTag("dmg").GetComponent<Transform>();
        navigationEnemy = GameObject.FindGameObjectWithTag("dmg").GetComponent<NavigationEnemy>();
        player = LayerMask.GetMask("Player");
        bullet = GameObject.FindGameObjectWithTag("shotDmg").GetComponent<Rigidbody>();
    }

    void Update() {
        StartCoroutine(shooting());
     
        Debug.Log(cloneBullet);
    }

    public IEnumerator shooting()
    {
        while (navigationEnemy.isHitPlayer().Equals(true))
        { 
            
                instanciate();
            cloneBullet.AddRelativeForce(transform.TransformDirection(Vector3.forward *5)  , ForceMode.Impulse);
               

          yield return new WaitForSeconds(20f);
        }   
    }

    void instanciate()
        {

        Vector3 height = new Vector3(0, 1f, 0);
        shootStart = dmgEnemy.transform.position + height;
        ray = new Ray(shootStart, dmgEnemy.transform.forward);
        Debug.DrawRay(shootStart, dmgEnemy.transform.forward,Color.red);

        Quaternion rotation = new Quaternion(0, 0, 0, 0);
        if (cloneBullet == null)
            {
                cloneBullet = Instantiate(bullet, shootStart, rotation, dmgEnemy);
               // Destroy(cloneBullet.gameObject, 1.5f);
           // LifeBar.sharedInstand.decreaseLife(costDamage);
            }
    }

   
           
    }
        

 

