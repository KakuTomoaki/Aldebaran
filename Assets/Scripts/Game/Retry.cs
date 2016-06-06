using UnityEngine;
using System.Collections;

public class Retry : MonoBehaviour {

    public void NextScene()
    {
        if (Application.loadedLevelName == "Game")
        {
            //初期化フラグをたてる
            GlobalVariableScript.isInitializeAll = true;

            Application.LoadLevel(Application.loadedLevelName);
        }
    }
}
