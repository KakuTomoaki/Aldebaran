using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ContinueYes : MonoBehaviour {

    // Use this for initialization
    public void NextScene()
    {
        //今いるシーンがtestという名前であれば、testという名前のシーンに移動する
        if (Application.loadedLevelName == "Game")
        {
            //Pause Buttonを有効化
            GameObject.Find("Canvas/Pause").GetComponent<Button>().interactable = true;

            //スコアを保持しておく
            GlobalVariableScript.ScoreSave = Score.instance.score;

            Application.LoadLevel(Application.loadedLevelName);
        }
    }
}
