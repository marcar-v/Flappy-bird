using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
    [SerializeField] GameObject gameOverMenu;
    public void Resume()
    {
        gameOverMenu.SetActive(false);
        SceneManager.LoadScene(1);
    }
}
