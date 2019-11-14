using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBarMinion : AbstractLifeBar {
    GameObject minion;
    private void Awake()
    {
        minion = this.gameObject;
        minion.layer = LayerMask.NameToLayer("NotAlly");
    }


    protected override void lifeOut()
    {
        if (minion.layer == 11 && this.currentLife == minLife) {
            minion.layer = LayerMask.NameToLayer("Player");
            this.currentLife = this.maxLife;
        }
        else if(minion.layer == 9 && this.currentLife == minLife)
        {
            minion.layer = LayerMask.NameToLayer("NotAlly");
            this.currentLife = this.maxLife;
        }
    }
}
