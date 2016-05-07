using UnityEngine;
using System.Collections;

public class SetSEVolume : MonoBehaviour{

    AudioSource[] audioSource = new AudioSource[10];

    void Start()
    {
        audioSource = GetComponents<AudioSource>();
        for (int i = 0; i < 10; i++)
        {
            audioSource[i].volume = PlayerPrefs.GetFloat(GlobalVariableScript.SEVolumePrefs, 1);
        }
    }
}