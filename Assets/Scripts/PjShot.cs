using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PjShot : InstantiateShot {

    Transform pointSpawnShuriken;
	// Use this for initialization
	void Start () {

        pointSpawnShuriken = this.transform.Find("PointSpawnShuriken");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            shurikenInstance();
        }
        if (Input.GetMouseButtonDown(0))
            Debug.Log("Pressed primary button.");
    }
    
    void shurikenInstance()
    {
        this.shot();
        Debug.Log(ForceMode.Impulse.GetType());
    }
    protected override void setUpShotVariables()
    {
        this.shotSpawnPoint = pointSpawnShuriken.position;
        this.shotForceVector = transform.TransformDirection(new Vector3(0, 0, 30));
       // this.forceMode = ForceMode.Impulse;
    }

}
