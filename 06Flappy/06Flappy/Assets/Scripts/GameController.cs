using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
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
    [SerializeField] Text bestTimeText;
    private GameTime gameTimeScript;

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
        bestTimeText.text = PlayerPrefs.GetFloat("BestTime", 0).ToString();
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
        float minutes = time / 60;
        float seconds = Mathf.Floor(time % 60);
        if (time > PlayerPrefs.GetFloat("BestTime"))
        {
            PlayerPrefs.SetFloat("BestTime", time);
            PlayerPrefs.Save();
            bestTimeText.text = "Best time:" + minutes.ToString("00") + ":" + seconds.ToString("00");
            //bestTimeText.text = "Best time: " + PlayerPrefs.GetFloat("BestTime");
        }
    }
    public void BirdDie()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        bestTimeText.text = "Best time: " + PlayerPrefs.GetFloat("BestTime");
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
