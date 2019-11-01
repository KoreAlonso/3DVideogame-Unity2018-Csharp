using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShot : InstantiateShot {

    NavigationBoss navBoss;
    Collider playerCollider;
    Rigidbody cloneSpell;
    Transform pointSpawn;

    bool canBossShoot;

    private void Start()
    {

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
                this.shot();
                canBossShoot = false;
            }
        }
    }

    protected override void setUpShotVariables()
    {
        //Initialize shot variables
        this.shotSpawnPoint = this.transform.Find("PointSpawnBullet").position;
        this.shotForceVector = transform.TransformDirection(new Vector3(0f, 5.3f, 10f));
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.Equals(playerCollider))
        {
            canBossShoot = true;
        }
    }

}
