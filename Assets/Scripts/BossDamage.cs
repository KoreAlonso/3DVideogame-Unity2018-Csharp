using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : MonoBehaviour {

    TerrainCollider colTerrain;

    private void Start()
    {
        colTerrain = FindObjectOfType<TerrainCollider>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other == colTerrain)
        {
            Destroy(this.gameObject);
        }
    }
}
