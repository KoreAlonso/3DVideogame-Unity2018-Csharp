using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//hereda de InstantiateShot.Encargado del disparo del boss
public class BossShot : InstantiateShot {

    NavigationBoss navBoss;
    Collider playerCollider;

    Transform pointSpawnSpell;
    Vector3 forceVectorSpell;

    bool canBossShoot;

    private void Start()
    {
        navBoss = FindObjectOfType<NavigationBoss>(); 
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>();

        forceVectorSpell = new Vector3(0f, 5.3f, 8f);
        pointSpawnSpell = this.transform.Find("PointSpawnBullet");

        canBossShoot = true;
    }

    private void OnTriggerStay(Collider other)

    {   //si esta player en colliderBoss y este esta quieto, lo mira.
        if (other.Equals(playerCollider) && navBoss.isBossStop == true)
        {   
            navBoss.boss.transform.LookAt(navBoss.playerTransf);

                //y si esta a rango, dispara (hacia, desde) 
            if (navBoss.isBossHitting().Equals(true) && canBossShoot == true)
            {
                this.shot(transform.TransformDirection(forceVectorSpell), pointSpawnSpell.position);
                canBossShoot = false;

               
            }
        }
        //Si vuelve a moverse, puede volver a disparar
        if (navBoss.isBossStop == false)
                {
                    canBossShoot = true;
                }
    }

}
