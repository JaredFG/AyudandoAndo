using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolController : MonoBehaviour
{
    public enum ToolType
    {
        Wrench,
        Hammer,
        Plunger,
        Saw
    }

    [SerializeField] private List<GameObject> tools;
    private int currentIndex;
    public ToolType currentTool;

    public void EquipTool(int index)
    {
        tools[currentIndex].SetActive(false);
        tools[index].SetActive(true);
        currentIndex = index;
        currentTool = tools[index].GetComponent<Tool>().toolType;
    }
}
