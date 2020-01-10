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
        navBoss = this.gameObject.GetComponentInParent<NavigationBoss>(); 
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>();

        forceVectorSpell = new Vector3(0f,- 4f, 16f);
        pointSpawnSpell = this.transform.Find("PointSpawnBullet");

        canBossShoot = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.Equals(playerCollider) && navBoss.isBossStop == true)
        {
            this.navBoss.boss.transform.LookAt(navBoss.playerTransf);
        }
    }
    private void OnTriggerStay(Collider other)

    {   //si esta player en colliderBoss y este esta quieto, lo mira.
        if (/*other.Equals(playerCollider) &&*/ navBoss.isBossStop == true)
        {
          this.navBoss.boss.transform.LookAt(navBoss.playerTransf);
            Debug.Log("miro al pj");
            

                //y si esta a rango, dispara (hacia, desde) 
            if (navBoss.isBossHitting().Equals(true) && canBossShoot == true)
            {   
                this.shot(transform.TransformDirection(forceVectorSpell), pointSpawnSpell.position);
                Debug.Log("disparo y no puedo disparar");
                canBossShoot = false;
                navBoss.resetCounter();
            }
        }
        //Si vuelve a moverse, puede volver a disparar
        if (navBoss.isBossStop == false)
                { 
            Debug.Log(  "puede disparar");
                    canBossShoot = true;
                }

      
       // Debug.Log(navBoss.isBossHitting() + " esta a rango");
    }

}
