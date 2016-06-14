using UnityEngine;
using System.Collections;

public class Retry : MonoBehaviour {

    public void NextScene()
    {
        if (Application.loadedLevelName == "Game")
        {
            //初期化フラグをたてる
            GlobalVariableScript.isInitializeAll = true;
            GlobalVariableScript.isGameOver_BGM = false;         // BGM再生停止フラグOFF

            Application.LoadLevel(Application.loadedLevelName);
        }
    }
}
