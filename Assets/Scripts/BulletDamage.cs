using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour {

    private void OnCollisionEnter(Collision collider)
    {
        Debug.Log("collision");
        Destroy(this.gameObject);
       
        
    }
}
