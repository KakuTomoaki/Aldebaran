using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SEVolume : MonoBehaviour
{

    private Slider slider;

    // Use this for initialization
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat(GlobalVariableScript.SEVolumePrefs, 1);
    }

    void Update()
    {
        PlayerPrefs.SetFloat(GlobalVariableScript.SEVolumePrefs, slider.value);
    }
}