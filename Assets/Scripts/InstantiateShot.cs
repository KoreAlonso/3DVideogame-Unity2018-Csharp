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

    protected virtual void shot()
    {
        this.setUpShotVariables();
        cloneShot = Instantiate(baseShot, shotSpawnPoint, shotOrientation);
        cloneShot.AddForce(shotForceVector, forceMode);
    }
}
