using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjective : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectives = new List<GameObject>();
    [SerializeField] private List<string> texts = new List<string>();

    [HideInInspector] public int selectedCase;
    [HideInInspector] public string selectedLabel;

    void Start()
    {
        Debug.Log("Spawn");
        selectedCase = Random.Range(0, objectives.Count);
        selectedLabel = texts[Random.Range(0, texts.Count)];

        GameObject instance = Instantiate(objectives[selectedCase], transform);
        instance.GetComponent<RandomText>().SetText(selectedLabel);
    }
}
