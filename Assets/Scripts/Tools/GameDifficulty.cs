using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum Difficulty { easy, normal, hard }

public class GameDifficulty : MonoBehaviour
{
 

    public static GameDifficulty sharedInstance;
    public static Difficulty difficultyMode;
    public Image panelEasy, panelNormal, panelHard;
    public Image recordEasy, recordNormal, recordHard;

    public List<GameObject> listBosses = new List<GameObject>();
    public static  List<GameObject> currentListBosses = new List<GameObject>();
    int easyNumBoss = 1, normalNumBoss = 4, hardNumBoss = 7;

    public static bool winConditionBosses = false;



    private void Awake()
    {
        //difficultyMode = Difficulty.easy;
        sharedInstance = this;
        listBosses = new List<GameObject>(GameObject.FindGameObjectsWithTag("Boss"));
        foreach (GameObject boss in listBosses)
        {
            boss.SetActive(false);
        }
        
            DontDestroyOnLoad(this);
      

    }
    private void Update()
    {
        checkWinCondition();
    }

    public void easyMode()
    {
        difficultyMode = Difficulty.easy;
        
    }

    public void normalMode()
    {
        difficultyMode = Difficulty.normal;
   
    }

    public void hardMode()
    {    
        difficultyMode = Difficulty.hard;
    }
    void hideBosses()
    {
        for(int i = 0; i < listBosses.Count; i++)
        {
            listBosses[i].SetActive(false);
        }
    }

    public void playDifficulty()
    {
        switch (difficultyMode)
        {
            case Difficulty.easy:
               
                for (int i = 0; i < easyNumBoss; i++)
                {
                    listBosses[i].SetActive(true);
                    currentListBosses.Add(listBosses[i]);
                }
                panelEasy.enabled = true;
                panelNormal.enabled = false;
                panelHard.enabled = false;

                recordEasy.enabled = true;
                recordNormal.enabled = false;
                recordHard.enabled = false;
                break;

            case Difficulty.normal:
                for (int i = 0; i < normalNumBoss; i++)
                {
                    listBosses[i].SetActive(true);
                    currentListBosses.Add(listBosses[i]);

                }
                panelNormal.enabled = true;
                panelEasy.enabled = false;
                panelHard.enabled = false;

                recordEasy.enabled = false;
                recordNormal.enabled = true;
                recordHard.enabled = false;

                break;
            case Difficulty.hard: 
               
                for (int i = 0; i < hardNumBoss; i++)
                {
                    listBosses[i].SetActive(true);
                    currentListBosses.Add(listBosses[i]);

                }
                panelHard.enabled = true;
                panelEasy.enabled = false;
                panelNormal.enabled = false;

                recordEasy.enabled = false;
                recordNormal.enabled = false;
                recordHard.enabled = true;


                break;
        }
    } 
    

    public static T assignDifficulty<T>(T easy, T normal, T hard)
    {
        T difficulty;
        if (difficultyMode == Difficulty.easy)
        {
            difficulty = easy;
        }
        else if (difficultyMode == Difficulty.normal)
        {
            difficulty = normal;
        }
        else
        {
            difficulty = hard;
        }

        return difficulty;
    }

    void checkWinCondition() {

        winConditionBosses = currentListBosses.Count == 0;

    }



}
