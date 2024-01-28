using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolController : MonoBehaviour
{
    [SerializeField] private List<GameObject> tools;
    private int currentIndex;

    private void Start()
    {
        currentIndex = 0;
        tools[currentIndex].SetActive(true);
    }

    public void EquipTool(int index)
    {
        tools[currentIndex].SetActive(false);
        tools[index].SetActive(true);
        currentIndex = index;
    }
}
