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

        shoot();
        Debug.Log(cloneBullet);
    }

    void shoot()
    {
        if(navigationEnemy.isHitPlayer().Equals(true) ) {

            StartCoroutine(shooting());

        }
        else
        {
            StopCoroutine(shooting());
        }

    }

    public IEnumerator shooting()
    {
        Vector3 height = new Vector3(0, 1f, 0);
        shootStart = dmgEnemy.transform.position + height;
        ray = new Ray(shootStart, dmgEnemy.transform.forward);
        Debug.DrawRay(shootStart, dmgEnemy.transform.forward,Color.red);
        
         
        /*if (Physics.SphereCast(shootStart, 1f, transform.forward, out hit, 200))*/
        while (Physics.SphereCast(ray, 1f, 10f, player)){ 
                {

                instanciate();
                cloneBullet.velocity = transform.TransformDirection(Vector3.forward) * 1;
                //LifeBar.sharedInstand.decreaseLife(costDamage);

            }
          yield return new WaitForSeconds(20f);
        }

       
    }
    void instanciate()
        {Debug.Log("hola");
        Quaternion rotation = new Quaternion(0, 0, 0, 0);
        if (cloneBullet == null)
        {
        
            cloneBullet = Instantiate(bullet, shootStart, rotation, dmgEnemy);
            
            Destroy(cloneBullet, 7f);
           
        }
        

    }
        

 
}
