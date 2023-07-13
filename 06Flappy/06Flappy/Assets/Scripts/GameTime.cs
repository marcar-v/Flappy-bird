using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    public Text timeText;
    private GameController gameController;
    public string minutes;
    public string seconds;
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

        minutes = Mathf.Floor(gameController.time / 60).ToString("00");
        seconds = Mathf.Floor(gameController.time % 60).ToString("00");

        return minutes + ":" + seconds;
    }
}
