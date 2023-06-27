using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    public float delay = 0.5f;
    
    public void PressStart()
    {
        Invoke("StartGameButton", delay);
    }
    public void StartGameButton()
    {
        SceneManager.LoadScene(1);
    }
}
