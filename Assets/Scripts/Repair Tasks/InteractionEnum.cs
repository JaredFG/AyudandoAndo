using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum ActionType
{
    Action1,
    Action2,
    Action3,
    Action4,
    Action5,
    Action6
}

public class InteractionEnum : MonoBehaviour
{
    public ActionType linkedAction;

    public void PerformRepairAction()
    {
        var taskManager = GameObject.Find("Repair Task Manager");

        switch (linkedAction)
        {
            case ActionType.Action1:
                taskManager.GetComponent<RepairTaskManager>().Toilet_PerformTask(1);
                break;
            case ActionType.Action2:
                taskManager.GetComponent<RepairTaskManager>().Toilet_PerformTask(2);
                break;
            case ActionType.Action3:
                taskManager.GetComponent<RepairTaskManager>().Toilet_PerformTask(3);
                break;
            case ActionType.Action4:
                taskManager.GetComponent<RepairTaskManager>().Toilet_PerformTask(4);
                break;
            case ActionType.Action5:
                taskManager.GetComponent<RepairTaskManager>().Toilet_PerformTask(5);
                break;
            case ActionType.Action6:
                taskManager.GetComponent<RepairTaskManager>().Toilet_PerformTask(6);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
