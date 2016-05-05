using UnityEngine;
using System.Collections;

public class SetBGMVolume : MonoBehaviour
{

    AudioSource[] audioSource = new AudioSource[10];
    //AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponents<AudioSource>();
        for (int i = 0; i < 10; i++)
        {
            audioSource[i].volume = PlayerPrefs.GetFloat(GlobalVariableScript.BGMVolumePrefs, 1);
        }
    }
}