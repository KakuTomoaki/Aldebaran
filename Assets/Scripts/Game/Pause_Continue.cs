using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pause_Continue : MonoBehaviour {

    private GameObject canvas;

    void Start()
    {
        canvas = GameObject.Find("Canvas_Pause");
    }
    // Use this for initialization
    public void Continue () {

        //表示用オブジェクト
        Image image;

        Time.timeScale = 1;

        //Pause Menuを非表示
        canvas = GameObject.Find("Canvas_Pause");
        canvas.GetComponent<Canvas>().enabled = false;

        //Pause Buttonを表示
        image = GameObject.Find("Canvas/Pause").GetComponent<Image>();
        image.enabled = true;

        //        //BGMの一時停止フラグON
        //        GlobalVariableScript.isPause_BGM = true;	
    }
}
