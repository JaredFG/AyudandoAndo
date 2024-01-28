using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairTaskManager : MonoBehaviour
{
    public static RepairTaskManager Instance { get; private set; }
    
    [Header("Task Managers")]

    [SerializeField] private ToiletTaskManager toiletTaskManager;

    [Header("Session variables")] 
    [SerializeField] private int taskHp;
    [SerializeField] private int tasksDone;
    
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
        if (taskHp <= 0)
        {
            Debug.Log("GAME OVER");
        }

        if (tasksDone >= 2)
        {
            Debug.Log("YOU WIN");
        }
    }
}
