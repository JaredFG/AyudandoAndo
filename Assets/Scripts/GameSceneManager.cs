using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject gameView;
    [SerializeField] private GameObject pauseView;
    [SerializeField] private GameObject gamewin;
    [SerializeField] private GameObject gamelose;
    [SerializeField] private GameObject endVoice;
    [SerializeField] private Button menuButton1;
    [SerializeField] private Button menuButton2;

    [SerializeField] private float delayBeforeLoad = 5.0f;

    private void Start()
    {
        if (gameView != null && pauseView != null)
        {
            gameView.SetActive(true);
            pauseView.SetActive(false);
        }

    }

    public void PauseMenu()
    {
        if (gameView != null && pauseView != null)
        {
            gameView.SetActive(false);
            pauseView.SetActive(true);
            Time.timeScale = 0.0f;
        }

    }

    public void ResumeButton()
    {
        if (gameView != null && pauseView != null)
        {
            gameView.SetActive(true);
            pauseView.SetActive(false);
            Time.timeScale = 1.0f;
        }

    }

    public void QuitButton()
    {
        if (gameView != null && pauseView != null)
        {
            gameView.SetActive(false);
            pauseView.SetActive(false);
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("ModeSelectionScene");
        }

    }
    public void StartButton()
    {
        SceneManager.LoadScene("ModeSelectionScene");
    }
    public void UserButton()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void OperatorButton()
    {
        SceneManager.LoadScene("Manual");
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("ModeSelectionScene");
    }
    public void ManualButton()
    {
        SceneManager.LoadScene("ManualScene");
    }
    /////////////////////////
    //Win
    public void ShowWinCanvas()
    {
        if (gamewin != null)
        {
            menuButton1.interactable=false;
            menuButton2.interactable=false;
            gamelose.SetActive(true);
            gamewin.SetActive(false);
            MusicManager.Instance.ChangeMusic("Win");
        }
        //Activar canvas de ganar
    }
    /////////////////////////
    //Lose
    public void ShowLoseCanvas()
    {
        if (gamelose != null)
        {
            menuButton1.interactable=false;
            menuButton2.interactable=false;
            gamelose.SetActive(true);
            gamewin.SetActive(false);
            MusicManager.Instance.ChangeMusic("Lose");
        }

    }
    public void ShowEndVoiceAndLoadScene()
    {
        if (endVoice != null)
        {
            endVoice.SetActive(true);
        }
        Invoke("LoadModeSelectionScene", delayBeforeLoad);
    }
    private void LoadModeSelectionScene()
    {
        SceneManager.LoadScene("ModeSelectionScene");
    }

}
