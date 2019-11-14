using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShot : InstantiateShot {

    NavigationBoss navBoss;
    Collider playerCollider;
    Rigidbody cloneSpell;
    Transform pointSpawnSpell;
    Vector3 forceVectorSpell;

    bool canBossShoot;

    private void Start()
    {
        forceVectorSpell = new Vector3(0f, 5.3f, 10f);
        pointSpawnSpell = this.transform.Find("PointSpawnBullet");
        navBoss = FindObjectOfType<NavigationBoss>(); 
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>();
        canBossShoot = true;
    }

    private void OnTriggerStay(Collider other)
    { 
        if (other.Equals(playerCollider) && navBoss.isBossStop == true)
        {   
            navBoss.boss.transform.LookAt(navBoss.playerTransf);
            
                if (navBoss.isBossHitting().Equals(true) && canBossShoot == true)
                {
                this.shot(transform.TransformDirection(forceVectorSpell), pointSpawnSpell.position);
                canBossShoot = false;
            }
        }
    }

   protected override void setUpShotVariables(){}

    private void OnTriggerExit(Collider other)
    {
        if(other.Equals(playerCollider))
        {
            canBossShoot = true;
        }
    }

}
