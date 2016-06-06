using UnityEngine;
using System.Collections;

public class TopMenu : MonoBehaviour {

    public void NextScene()
    {
        //今いるシーンがtestという名前であれば、testという名前のシーンに移動する
        if (Application.loadedLevelName == "Game")
        {
            //初期化フラグをたてる
            GlobalVariableScript.isInitializeAll = true;

            Time.timeScale = 1;

            Application.LoadLevel("Menu");
        }
    }
}
