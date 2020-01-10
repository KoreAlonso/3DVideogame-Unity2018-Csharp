using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameTimer : MonoBehaviour
{

    public static float initialTime = 0, currentTime;
    public static GameTimer sharedInstance;
    static float easyMaxTime = 150f, normalMaxTime = 180f, hardMaxTime = 210f, finalTime;


    private void Awake()
    {
        sharedInstance = this;
       
            DontDestroyOnLoad(this);
        
    }
    void Start()
    {

        currentTime = initialTime;
    }
    private void Update()
    {
        CounterGame();


    }


    void CounterGame()
    {
        if (GameManager.sharedInstance.inGameCanvas.isActiveAndEnabled)
        {
            if (currentTime < finalTime)
            {
                currentTime += Time.deltaTime;
            }
            else
            {
                currentTime = finalTime;
                GameManager.sharedInstance.gameOver();
            
            }
            float timeOut = finalTime - currentTime;
            float minutes = (int)timeOut / 60;
            float seconds = (int)timeOut - (minutes * 60);
            string minuteText = minutes < 10 ? "0" + minutes : minutes.ToString();
            string secondsText = seconds < 10 ? "0" + seconds : seconds.ToString();
            GameObject.FindGameObjectWithTag("timerText").GetComponent<Text>().text = minuteText + ":" + secondsText;
        }
    }

    //mirar esto bien
    public static float recordTime()
    {

        return  currentTime;

    }
    public static void setTime()
    {
        finalTime = GameDifficulty.assignDifficulty<float>(easyMaxTime, normalMaxTime, hardMaxTime);

    }
}
