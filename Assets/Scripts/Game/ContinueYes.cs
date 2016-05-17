using UnityEngine;
using System.Collections;

public class ContinueYes : MonoBehaviour {

    // Use this for initialization
    public void NextScene()
    {
        //今いるシーンがtestという名前であれば、testという名前のシーンに移動する
        if (Application.loadedLevelName == "Game")
        {
            Application.LoadLevel(Application.loadedLevelName);
        }
    }
}
