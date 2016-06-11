using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pause_Continue : MonoBehaviour {

    private GameObject canvas_pause;

    void Start()
    {
        canvas_pause = GameObject.Find("Canvas_Pause");
    }

    // Use this for initialization
    public void Continue () {
        Time.timeScale = 1;

        //Pause Menuを非表示
        canvas_pause = GameObject.Find("Canvas_Pause");
        canvas_pause.GetComponent<Canvas>().enabled = false;

        //Pause Buttonを有効化
        GameObject.Find("Canvas/Pause").GetComponent<Button>().interactable = true;

        //        //BGMの一時停止フラグON
        //        GlobalVariableScript.isPause_BGM = true;	
    }
}
