using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBarBoss : AbstractLifeBar {

   
    protected override void lifeOut()
    {
        GameDifficulty.currentListBosses.Remove(this.gameObject);
        this.gameObject.SetActive(false);
    }
}
