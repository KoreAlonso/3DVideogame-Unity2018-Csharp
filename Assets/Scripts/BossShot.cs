using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShot : MonoBehaviour {

    NavigationBoss navBoss;
    Collider playerCollider;

    public Rigidbody bossSpell;
    Rigidbody cloneSpell;
    Transform pointSpawn;

    bool canBossShoot;

    private void Start()
    {
        
        pointSpawn = this.transform.Find("PointSpawnBullet");
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

                    
                Quaternion rotation = new Quaternion(0, 0, 0, 0);
                cloneSpell = Instantiate(bossSpell, pointSpawn.position, rotation);
                cloneSpell.AddForce(transform.TransformDirection(new Vector3(0f, 5.3f, 10f)), ForceMode.Impulse);
                canBossShoot = false;
      
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.Equals(playerCollider))
        {
            canBossShoot = true;
        }
    }

}
