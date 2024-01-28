using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RepairTaskManager : MonoBehaviour
{
    public static RepairTaskManager Instance { get; private set; }
    
    [Header("Task Managers")]

    [SerializeField] private ToiletTaskManager toiletTaskManager;
    [SerializeField] private GameSceneManager gameSceneManager;

    [Header("Session variables")] 
    [SerializeField] private int taskHp;
    [SerializeField] private int tasksDone;

    [Header("UI And GameStates")] 
    [SerializeField] private Image integrityBar;
    [SerializeField] private TextMeshProUGUI textLabel;

    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    private void Update()
    {
        integrityBar.fillAmount = (taskHp / 3);
        textLabel.text = taskHp.ToString();
    }

    public void Toilet_PerformTask(int taskId)
    {
        toiletTaskManager.PerformStep(taskId);
    }

    public void MarkMistake()
    {
        taskHp--;
        CheckGameState();
    }

    public void FinishedTask()
    {
        tasksDone++;
        CheckGameState();
    }
    
    private void CheckGameState()
    {
        Debug.Log($"TaskHP = %{taskHp}");
        
        if (taskHp <= 0)
        {
            gameSceneManager.ShowLoseCanvas();
            Debug.Log("GAME OVER");
        }

        if (tasksDone >= 2)
        {
            gameSceneManager.ShowWinCanvas();
            Debug.Log("YOU WIN");
        }
    }
}
