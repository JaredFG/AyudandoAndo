using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolController : MonoBehaviour
{
    [SerializeField] private List<GameObject> tools;
    private int currentIndex;

    public void EquipTool(int index)
    {
        tools[currentIndex].SetActive(false);
        tools[index].SetActive(true);
        currentIndex = index;
    }
}
