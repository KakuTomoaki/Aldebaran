using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour {

    private GameObject canvas;

    void Start()
    {
        canvas = GameObject.Find("Canvas_Pause");
    }

    public void Pause()
    {
        //表示用オブジェクト
        Text text;
        Image image;

        Time.timeScale = 0;

        //Pause Menuを表示
        canvas = GameObject.Find("Canvas_Pause");
        canvas.GetComponent<Canvas>().enabled = true;

        //Pause Buttonを非表示
        image = GameObject.Find("Canvas/Pause").GetComponent<Image>();
        image.enabled = false;

        //        //BGMの一時停止フラグON
        //        GlobalVariableScript.isPause_BGM = true;

    }
}
