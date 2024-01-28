using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomText : MonoBehaviour
{
    [SerializeField] private List<Transform> textSpawns = new List<Transform>();
    [SerializeField] private GameObject textObject;

    private GameObject instance;
    private string label;

    void Start()
    {
        Debug.Log("Write");
        instance = Instantiate(textObject, textSpawns[Random.Range(0, textSpawns.Count)]);
        instance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = label;
    }

    public void SetText(string text)
    {
        label = text;
    }
}
