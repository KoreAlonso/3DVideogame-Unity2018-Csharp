using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InstantiateShot : MonoBehaviour {
    //Shot instance
    protected Rigidbody cloneShot;

    //Shot instantiate variables
    public Rigidbody baseShot;
    protected Vector3 shotSpawnPoint;
    Quaternion shotOrientation = new Quaternion(0, 0, 0, 0);
  

    //Shot force variables
    protected Vector3 shotForceVector;
    protected ForceMode forceMode = ForceMode.Impulse;


    protected abstract void setUpShotVariables();


    protected virtual void shot(Vector3? forceVector, Vector3? spawnPoint)
    {
      //CONDICIONALES TERNARIOS   //  value = (condition)   ?      trueCase : falseCase;
        Vector3 finalForceVector = (forceVector == null) ? shotForceVector : (Vector3) forceVector;

        Vector3 finalSpawnPoint = (spawnPoint == null )? shotSpawnPoint : (Vector3)spawnPoint;


        this.setUpShotVariables();
        cloneShot = Instantiate(baseShot, finalSpawnPoint, shotOrientation);
        if(this.gameObject.layer != LayerMask.NameToLayer("Boss")) cloneShot.gameObject.GetComponent<Spell>().layerOrigin = this.gameObject.layer;
        cloneShot.AddForce(finalForceVector, forceMode);
    }
}
