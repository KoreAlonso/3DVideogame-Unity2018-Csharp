using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//encargado del comportamiento de la bala del boss
public class BossSpell : MonoBehaviour {

    TerrainCollider colTerrain;
    int damage = 7;

    private void Start()
    {
        colTerrain = FindObjectOfType<TerrainCollider>();
    }
    //si un componente con vida de la capa Player entra, resta su vida.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<AbstractLifeBar>() && other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            
            other.gameObject.GetComponent<AbstractLifeBar>().decreaseLife(damage);
        }

    }
    //cuando impacta con el suelo, se destruye. 
    private void OnTriggerExit(Collider other)
    {
        if (other == colTerrain)
        {
            Destroy(this.gameObject);
        }

    }

   
}
