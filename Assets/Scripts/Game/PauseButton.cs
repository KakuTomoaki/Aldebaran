using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour {

    private GameObject canvas_pause;
    private Button pause;

    void Start()
    {
        canvas_pause = GameObject.Find("Canvas_Pause");
        pause = GameObject.Find("Canvas/Pause").GetComponent<Button>();
    }

    public void Pause()
    {
        if(pause.interactable == true) {
            Time.timeScale = 0;

            //Pause Menuを表示
            canvas_pause = GameObject.Find("Canvas_Pause");
            canvas_pause.GetComponent<Canvas>().enabled = true;

            //Pause Buttonを無効化
            GameObject.Find("Canvas/Pause").GetComponent<Button>().interactable = false;

            //        //BGMの一時停止フラグON
            //        GlobalVariableScript.isPause_BGM = true;
        }
    }
}
