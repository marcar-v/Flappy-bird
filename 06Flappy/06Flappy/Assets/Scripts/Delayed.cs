using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delayed : MonoBehaviour
{
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject homeButton;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject betterLuckText;
    [SerializeField] GameObject highScoreText;
    [SerializeField] GameObject bestTimeText;

    [SerializeField] float delayGameOver = 1f;
    [SerializeField] float delayButtons = 1.5f;
    
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
        bestTimeText.SetActive(true);
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
