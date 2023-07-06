using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    public Text timeText;
    private GameController gameController;
    void Start()
    {
        timeText.text = "Time: 00:00";
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameController.gameTime) 
        {
            timeText.text = "Time: " + ResetTime();
        }

        if(gameController.gameOver == true)
        {
            timeText.text = "Time: 00:00";
        }
    }

    public string ResetTime()
    {
        if (gameController.gameTime)
        {
            gameController.time += Time.deltaTime;
        }

        string minutes = Mathf.Floor(gameController.time / 60).ToString("00");
        string seconds = Mathf.Floor(gameController.time % 60).ToString("00");

        return minutes + ":" + seconds;
    }
}
