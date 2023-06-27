using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    
    public GameObject gameOverText;
    public bool gameOver;

    public float scrollSpeed = -1.5f;

    private int score;
    public Text scoreText;

    private int currentHighScore;
    private int highScore;
    public Text highScoreText;
    
    
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
    }

    public void BirdScored()
    {
        if (!gameOver)
        {
            score++;
            scoreText.text = "Score: " + score;
            SoundSystem.instance.PlayCoin();
        
            UpdateHighScore();
        }
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
    public void BirdDie()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        gameOverText.SetActive(true);
        gameOver = true;
    }

    private void OnDestroy()
    {
        if (GameController.instance == this)
        {
            GameController.instance = null;
        }
    }
}
