using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Text text;
        float fScore;

        text = GameObject.Find("Canvas/1st/Text").GetComponent<Text>();
        fScore = PlayerPrefs.GetFloat(GlobalVariableScript.Prefs_Score1st, 0);
        text.text = "1st. " + fScore.ToString();

        text = GameObject.Find("Canvas/2nd/Text").GetComponent<Text>();
        fScore = PlayerPrefs.GetFloat(GlobalVariableScript.Prefs_Score2nd, 0);
        text.text = "2nd. " + fScore.ToString();

        text = GameObject.Find("Canvas/3rd/Text").GetComponent<Text>();
        fScore = PlayerPrefs.GetFloat(GlobalVariableScript.Prefs_Score3rd, 0);
        text.text = "3rd. " + fScore.ToString();
    }
}
