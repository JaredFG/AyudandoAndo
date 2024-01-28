using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject gameView;
    [SerializeField] private GameObject pauseView;

    private void Start()
    {
        if(gameView!=null && pauseView!=null)
        {gameView.SetActive(true);
        pauseView.SetActive(false);}
        
    }

    public void PauseMenu()
    {
        if(gameView!=null && pauseView!=null)
        {gameView.SetActive(false);
        pauseView.SetActive(true);
        Time.timeScale = 0.0f;}
        
    }

    public void ResumeButton()
    {
        if(gameView!=null && pauseView!=null)
        {gameView.SetActive(true);
        pauseView.SetActive(false);
        Time.timeScale = 1.0f;}
        
    }

    public void QuitButton()
    {
        if(gameView!=null && pauseView!=null)
        {gameView.SetActive(false);
        pauseView.SetActive(false);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("ModeSelectionScene");}
        
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
        MusicManager.Instance.ChangeMusic("Win");    
        //Activar canvas de ganar
    }
    /////////////////////////
    //Lose
    public void ShowLoseCanvas()
    {
        MusicManager.Instance.ChangeMusic("Lose");    
    }
}
