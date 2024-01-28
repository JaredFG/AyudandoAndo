using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject gameView;
    [SerializeField] private GameObject pauseView;

    private void Start()
    {
        gameView.SetActive(true);
        pauseView.SetActive(false);
    }

    public void PauseMenu()
    {
        gameView.SetActive(false);
        pauseView.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void ResumeButton()
    {
        gameView.SetActive(true);
        pauseView.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void QuitButton()
    {
        gameView.SetActive(false);
        pauseView.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
