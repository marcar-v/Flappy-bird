using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delayed : MonoBehaviour
{
    public GameObject restartButton;
    public GameObject homeButton;
    public GameObject gameOverText;
    public GameObject betterLuckText;
    public GameObject highScoreText;

    public float delayGameOver = 1f;
    public float delayButtons = 1.5f;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke("EnableFlapToRestart", delayButtons);
        Invoke("EnableHomeButton", delayButtons);
        Invoke("EnableGameOverText", delayGameOver);
    }

    void EnableGameOverText()
    {
        gameOverText.SetActive(true);
        betterLuckText.SetActive(true);
        highScoreText.SetActive(true);
    }
    void EnableFlapToRestart()
    {
        restartButton.SetActive(true);
    }

    void EnableHomeButton()
    {
        homeButton.SetActive(true);
    }

}
