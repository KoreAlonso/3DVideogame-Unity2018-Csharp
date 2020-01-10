using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState
    {
        menu,inGame,overGame,winGame,sure,credits
    }


 class GameManager : MonoBehaviour {

    public Canvas menuCanvas, inGameCanvas, overGameCanvas, sureCanvas, creditsCanvas;
    public GameState currentScene;

    public static GameManager sharedInstance;
    // Use this for initialization
    private void Awake()
    {
        sharedInstance = this;
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        backToMenu();
    }
    private void Update()
    {
        checkWinCondition();
    }
    public void backToMenu()
    {
        setScene(GameState.menu);

    }
    public void inGame()
    {
        setScene(GameState.inGame);
        MoveCamera.sharedInstance.moveCamera();
        GameDifficulty.sharedInstance.playDifficulty();
        GameTimer.setTime();
    }
    public void gameOver()
    {    
        setScene(GameState.overGame);
    }
    public void areSure()
    {
        setScene(GameState.sure);
    }
    public void credits()
    {
        setScene(GameState.credits);
    }

    void setScene( GameState gameState)
    {
        this.currentScene = gameState;
        if(currentScene == GameState.menu)
        {
            menuCanvas.gameObject.SetActive(true);
            inGameCanvas.gameObject.SetActive(false);
            overGameCanvas.gameObject.SetActive(false);
            sureCanvas.gameObject.SetActive(false);
            creditsCanvas.gameObject.SetActive(false);

            Debug.Log("menu");
        }
         if(currentScene == GameState.inGame)
        {
            inGameCanvas.gameObject.SetActive(true);
            menuCanvas.gameObject.SetActive(false);
            overGameCanvas.gameObject.SetActive(false);
            sureCanvas.gameObject.SetActive(false);
            creditsCanvas.gameObject.SetActive(false);

            Debug.Log("inGame");
        }
         if(currentScene== GameState.overGame)
        {
            overGameCanvas.gameObject.SetActive(true);
            menuCanvas.gameObject.SetActive(false);
            inGameCanvas.gameObject.SetActive(false);
            sureCanvas.gameObject.SetActive(false);
            creditsCanvas.gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Defeat").gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("Victory").gameObject.SetActive(false);

            setViewRecord();

            Debug.Log("overGame");
        }
        
         if(currentScene == GameState.credits)
        {
            creditsCanvas.gameObject.SetActive(true);
            menuCanvas.gameObject.SetActive(false);
            inGameCanvas.gameObject.SetActive(false);
            overGameCanvas.gameObject.SetActive(false);
            sureCanvas.gameObject.SetActive(false);
        }
        if(currentScene == GameState.sure)
        {
           
            sureCanvas.gameObject.SetActive(true);
            menuCanvas.gameObject.SetActive(false);
            inGameCanvas.gameObject.SetActive(false);
            overGameCanvas.gameObject.SetActive(false);
            creditsCanvas.gameObject.SetActive(false);

            Debug.Log("sure?");
        }
        if(currentScene == GameState.winGame)
        {
            overGameCanvas.gameObject.SetActive(true);
            menuCanvas.gameObject.SetActive(false);
            inGameCanvas.gameObject.SetActive(false);
            sureCanvas.gameObject.SetActive(false);
            creditsCanvas.gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Defeat").gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Victory").gameObject.SetActive(true);

            setViewRecord();
        }
    }

    void setViewRecord()
    {
        int minutes, seconds;
        float savedRecord;
        savedRecord = GameDifficulty.assignDifficulty<float>(
            CreateJsonTest.record.recordEasyMode,
            CreateJsonTest.record.recordNormalMode,
            CreateJsonTest.record.recordHardMode);
        minutes = (int)savedRecord / 60;
        seconds = (int)savedRecord - (minutes * 60);
        string minuteText = minutes < 10? "0" + minutes : minutes.ToString() ;
        string secondsText = seconds < 10? "0" + seconds : seconds.ToString() ;
        GameObject.FindGameObjectWithTag("recordText").GetComponent<Text>().text = minuteText + ":" + secondsText;

    }

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void exitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit(); 
        #endif
    }

    void checkWinCondition()
    {
        if(GameDifficulty.winConditionBosses && MinionsType.winConditionMinion && currentScene == GameState.inGame)
        {
            switch (GameDifficulty.difficultyMode)
            {
                case Difficulty.easy:
                    {
                        CreateJsonTest.record.recordEasyMode = CreateJsonTest.record.recordEasyMode > GameTimer.recordTime() ? GameTimer.recordTime() : CreateJsonTest.record.recordEasyMode;
                        break;
                    }
                case Difficulty.normal:
                    {
                        CreateJsonTest.record.recordNormalMode = CreateJsonTest.record.recordNormalMode > GameTimer.recordTime() ? GameTimer.recordTime() : CreateJsonTest.record.recordNormalMode;
                        break;
                    }
                case Difficulty.hard:
                    {
                        CreateJsonTest.record.recordHardMode = CreateJsonTest.record.recordHardMode > GameTimer.recordTime() ? GameTimer.recordTime() : CreateJsonTest.record.recordHardMode;
                        break;
                    }
            }
            CreateJsonTest.writeTxt();
            setScene(GameState.winGame);
        }
    }
   
}
