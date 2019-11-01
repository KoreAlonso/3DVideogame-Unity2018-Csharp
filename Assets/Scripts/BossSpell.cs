using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpell : MonoBehaviour {

    TerrainCollider colTerrain;
    int damage = 7;

    private void Start()
    {
        colTerrain = FindObjectOfType<TerrainCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<AbstractLifeBar>())
        {
            
            other.gameObject.GetComponent<AbstractLifeBar>().decreaseLife(damage);
        }
       
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == colTerrain)
        {
            Destroy(this.gameObject);
        }
    }

   
}
