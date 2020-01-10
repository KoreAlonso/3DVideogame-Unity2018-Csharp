using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewGame : MonoBehaviour {
   // public List<Image> listPanel = new List<Image>();
    public Image panelEasy, panelNormal, panelHard;
   

    private void Start()
    {
       
    
    }
    private void Update()
    {
        if (GameManager.sharedInstance.inGameCanvas)
        {
            assignPanel();
            
        }
    }

    void assignPanel()
    {
        GameDifficulty.assignDifficulty<Image>(panelEasy, panelNormal, panelHard).enabled = true;
    }

}
