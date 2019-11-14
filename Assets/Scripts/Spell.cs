using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {

    int damage = 1;
    private void OnCollisionEnter(Collision collider)
    {   
        if (collider.gameObject.GetComponent<AbstractLifeBar>())
        {  
            collider.gameObject.GetComponent<AbstractLifeBar>().decreaseLife(damage);
           

            if (collider.gameObject.tag !="Player" && collider.gameObject.tag != "terrain")
            {
               Debug.Log("disparo acertado");
               

            }
        }
        else
        {
            Destroy(this.gameObject,1.5f);
            Debug.Log("disparo fallido");
        }   
        
         Destroy(this.gameObject);
    }
}
