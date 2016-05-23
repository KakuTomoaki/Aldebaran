using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pause_Continue : MonoBehaviour {

    // Use this for initialization
    public void Continue () {

        //表示用オブジェクト
        Text text;
        Image image;

        Time.timeScale = 1;

        //Pauseボタンを表示する
        image = GameObject.Find("Canvas/Pause").GetComponent<Image>();
        image.enabled = true;

        //半透明画像
        //image = GameObject.Find("Canvas/Base_Alpha70").GetComponent<Image>();
        //image.enabled = true;

        //Menuを非表示にする
        image = GameObject.Find("Canvas/Pause_Continue").GetComponent<Image>();
        image.enabled = false;
        text = GameObject.Find("Canvas/Pause_Continue/Text").GetComponent<Text>();
        text.enabled = false;

        image = GameObject.Find("Canvas/Pause_Retry").GetComponent<Image>();
        image.enabled = false;
        text = GameObject.Find("Canvas/Pause_Retry/Text").GetComponent<Text>();
        text.enabled = false;

        image = GameObject.Find("Canvas/Pause_TopMenu").GetComponent<Image>();
        image.enabled = false;
        text = GameObject.Find("Canvas/Pause_TopMenu/Text").GetComponent<Text>();
        text.enabled = false;

        //        //BGMの一時停止フラグON
        //        GlobalVariableScript.isPause_BGM = true;	
    }
}
