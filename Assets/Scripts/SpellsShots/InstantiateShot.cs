using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//encargado de crear disparo
public abstract class InstantiateShot : MonoBehaviour {
    //Intancia del disparo
    protected Rigidbody cloneShot;

    //Variables para la instancia de disparo
    public Rigidbody baseShot;
    protected Vector3 shotSpawnPoint;
    Quaternion shotOrientation = new Quaternion(0, 0, 0, 0);
  

    //varibles de fuerza para el disparo
    protected Vector3 shotForceVector;
    protected ForceMode forceMode = ForceMode.Impulse;


    //recibe la fuerza y desde donde.
    protected virtual void shot(Vector3? forceVector, Vector3? spawnPoint)
    {
      //CONDICIONALES TERNARIOS   //  value = (condition)   ?      trueCase : falseCase;
        Vector3 finalForceVector = (forceVector == null) ? shotForceVector : (Vector3) forceVector;
        Vector3 finalSpawnPoint = (spawnPoint == null )? shotSpawnPoint : (Vector3)spawnPoint;

        cloneShot = Instantiate(baseShot, finalSpawnPoint, shotOrientation);

        //si este no esta en la capa boss, cloneShot obtiene la layer de su origen. 
        if(this.gameObject.layer != LayerMask.NameToLayer("Boss")) cloneShot.gameObject.GetComponent<Spell>().layerOrigin = this.gameObject.layer;
        cloneShot.AddForce(finalForceVector, forceMode);
    }
}
