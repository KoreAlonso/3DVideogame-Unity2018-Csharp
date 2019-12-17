using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//encargado del comportamiento de la bala de minion y pj principal
public class Spell : MonoBehaviour {

    int damage = 1;
    public int layerOrigin;

    private void OnCollisionEnter(Collision collider)
    {  
        if (collider.gameObject.GetComponent<AbstractLifeBar>())
        {   
            //si es daño e impacta con Player, le baja vida.
            if (layerOrigin == LayerMask.NameToLayer("Dmg") && collider.gameObject.tag.Equals("Player")) {

                collider.gameObject.GetComponent<AbstractLifeBar>().decreaseLife(damage);
            }
            //si es healer e impacta con Player (minions aliados), les baja vida
            if(layerOrigin == LayerMask.NameToLayer("Healer") && collider.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                collider.gameObject.GetComponent<AbstractLifeBar>().decreaseLife(damage);
            }
            //si es Player e impacta con una capa distinta, le baja vida. 
            if (layerOrigin == LayerMask.NameToLayer("Player") && collider.gameObject.layer != LayerMask.NameToLayer("Player"))
            {
                collider.gameObject.GetComponent<AbstractLifeBar>().decreaseLife(damage);
 
            }
        }
        else
        {
            Destroy(this.gameObject,1.5f);
            Debug.Log("disparo fallido");
        }   
        //se destruye con el impacto, sino, al 1.5s
         Destroy(this.gameObject);
    }
}
