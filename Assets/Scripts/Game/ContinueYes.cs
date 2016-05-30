using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ContinueYes : MonoBehaviour {

    // Use this for initialization
    public void NextScene()
    {
        Image image;

        //今いるシーンがtestという名前であれば、testという名前のシーンに移動する
        if (Application.loadedLevelName == "Game")
        {
            //Pauseボタンを表示する
            image = GameObject.Find("Canvas/Pause").GetComponent<Image>();
            image.enabled = true;

            //スコアを保持しておく
            GlobalVariableScript.ScoreSave = Score.instance.score;

            Application.LoadLevel(Application.loadedLevelName);
        }
    }
}
