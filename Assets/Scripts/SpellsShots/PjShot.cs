using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//hereda de instantiateShot.Encargado de los disparo del Pj principal. 
public class PjShot : InstantiateShot {

    Transform pointSpawnShuriken;

    public float currentCount, minCount = 0,  maxCount = 1.1f, defaultCount= 1.1f;
    float costTripleShot = 5;
   


    void Start () {
        pointSpawnShuriken = this.transform.Find("PointSpawnShuriken");
        currentCount = maxCount;
        
    }

	void Update () {
        
        shotCounter();
        //solo puede disparar cuando el contador este en maxCount. Cuando se dispare, se iguala a minCount para que vuelva a ejecutarse la condicion.
        if (Input.GetMouseButtonDown(0) && currentCount == maxCount )
        {
            currentCount = minCount;
            this.shot(transform.TransformDirection(new Vector3(0, 3, 25)), pointSpawnShuriken.position);
        }
        //solo puede disparar si el costo del disparo en area en menos al total de energia.
        if (Input.GetMouseButtonDown(1) && costTripleShot < EnergyBar.sharedInstance.currentValue)
        {
            this.tripleShot();
            EnergyBar.sharedInstance.decrease(costTripleShot);
        }
    }

    //Encargado del disparo en area.Cada shot() se encarga de una bala.
    void tripleShot()
    {
        shot(transform.TransformDirection(new Vector3(0, 3, 25)), pointSpawnShuriken.position);
        shot(transform.TransformDirection(new Vector3(-5, 3, 25)), pointSpawnShuriken.position + new Vector3(1,0,0) );
        shot(transform.TransformDirection(new Vector3(5, 3, 25)), pointSpawnShuriken.position + new Vector3(-1, 0, 0));
    }
    
    float shotCounter()
    {
        //contador que se para al llegar a maxCount.
        if (minCount <= currentCount)
        {
            currentCount += Time.deltaTime;
        }
        if(currentCount >= maxCount)
        {
            currentCount = maxCount;
        }
        
        return currentCount;
    }

}
