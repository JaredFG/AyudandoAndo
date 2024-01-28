using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolButtonsUISound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip selectedClip;
    [SerializeField] private List<AudioClip> hoverClips;
    
    public void PlaySelected()
    {
        audioSource.PlayOneShot(selectedClip);
    }

    public void PlayRandonSound()
    {
        audioSource.PlayOneShot(hoverClips[Random.Range(0, hoverClips.Count)]);
    }
}
