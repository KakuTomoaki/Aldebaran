using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BGMVolume : MonoBehaviour
{

    private Slider slider;

    // Use this for initialization
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat(GlobalVariableScript.BGMVolumePrefs, 1);
    }

    void Update()
    {
        PlayerPrefs.SetFloat(GlobalVariableScript.BGMVolumePrefs, slider.value);
    }
}