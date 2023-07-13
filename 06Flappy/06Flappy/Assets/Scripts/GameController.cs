using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField] GameObject gameOverText;
    public bool gameOver;

    public float scrollSpeed = -1.5f;

    private int score;
    [SerializeField] Text scoreText;

    [SerializeField] int itemScore = 5;


    [SerializeField] Text highScoreText;

    public float time = 0;
    public bool gameTime = true;

    [SerializeField] Text bestTimeMinutesText;
    [SerializeField] Text bestTimeSecondsText;
    private float bestTime;
    [SerializeField] float bestTimeMinutes;
    [SerializeField] float bestTimeSeconds;
    [SerializeField] GameTime gameTimeInstance;

    private void Awake()
    {
        if (GameController.instance == null)
        {
            GameController.instance = this;
        }else if (GameController.instance != this)
        {
            Destroy(gameObject);
            Debug.LogWarning("GameController ha sido instanciado por segunda vez. No debería pasar");
        }
    }


    private void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        bestTime = PlayerPrefs.GetFloat("BestTime");
        bestTimeMinutesText.text = PlayerPrefs.GetString("BestTimeMinutes");
        bestTimeSecondsText.text = PlayerPrefs.GetString("BestTimeSeconds");
    }

    public void BirdScored()
    {
        if (!gameOver)
        {
            score++;
            scoreText.text = "Score: " + score;
            SoundSystem.instance.PlayScore();
        
            UpdateHighScore();
            UpdateBestTime();
        }
    }

    public void ItemScore()
    { 
        score = score + itemScore;
        scoreText.text = "Score: " + score;
        SoundSystem.instance.PlayCoin();
    }
    public void UpdateHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
            highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        }
    }
    public void UpdateBestTime()
    {
        if (time > bestTime)
        {
            bestTime = time;
            PlayerPrefs.SetFloat("BestTime", bestTime);
            PlayerPrefs.SetString("BestTimeMinutes", gameTimeInstance.minutes);
            PlayerPrefs.SetString("BestTimeSeconds", gameTimeInstance.seconds);
            PlayerPrefs.Save();
            bestTimeMinutesText.text = gameTimeInstance.minutes;
            bestTimeSecondsText.text = gameTimeInstance.seconds;
        }
    }
    public void BirdDie()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        bestTimeMinutesText.text = PlayerPrefs.GetString("BestTimeMinutes");
        bestTimeSecondsText.text = PlayerPrefs.GetString("BestTimeSeconds");
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
