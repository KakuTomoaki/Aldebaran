using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour {

    public void Pause()
    {
        //表示用オブジェクト
        Text text;
        Image image;

        Time.timeScale = 0;

        //Pauseボタンを消す
        image = GameObject.Find("Canvas/Pause").GetComponent<Image>();
        image.enabled = false;

        //半透明画像
        //image = GameObject.Find("Canvas/Base_Alpha70").GetComponent<Image>();
        //image.enabled = true;

        //Menuを表示する
        image = GameObject.Find("Canvas/Pause_Continue").GetComponent<Image>();
        image.enabled = true;
        text = GameObject.Find("Canvas/Pause_Continue/Text").GetComponent<Text>();
        text.enabled = true;

        image = GameObject.Find("Canvas/Pause_Retry").GetComponent<Image>();
        image.enabled = true;
        text = GameObject.Find("Canvas/Pause_Retry/Text").GetComponent<Text>();
        text.enabled = true;

        image = GameObject.Find("Canvas/Pause_TopMenu").GetComponent<Image>();
        image.enabled = true;
        text = GameObject.Find("Canvas/Pause_TopMenu/Text").GetComponent<Text>();
        text.enabled = true;

        //        //BGMの一時停止フラグON
        //        GlobalVariableScript.isPause_BGM = true;

    }
}
