using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PjShot : InstantiateShot {

    Transform pointSpawnShuriken;
	
	void Start () {

        pointSpawnShuriken = this.transform.Find("PointSpawnShuriken");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            this.shot(transform.TransformDirection(new Vector3(0, 3, 25)), pointSpawnShuriken.position);
        }
        if (Input.GetMouseButtonDown(1))
        {
            this.tripleShot();
        }

    }

    protected override void setUpShotVariables() { }
    

    void tripleShot()
    {
        shot(transform.TransformDirection(new Vector3(0, 3, 25)), pointSpawnShuriken.position);
        shot(transform.TransformDirection(new Vector3(-5, 3, 25)), pointSpawnShuriken.position + new Vector3(1,0,0) );
        shot(transform.TransformDirection(new Vector3(5, 3, 25)), pointSpawnShuriken.position + new Vector3(-1, 0, 0));
    }




}
