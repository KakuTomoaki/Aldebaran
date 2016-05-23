using UnityEngine;
using System.Collections;

public class Pause_TopMenu : MonoBehaviour {

    public void NextScene()
    {
        //今いるシーンがtestという名前であれば、testという名前のシーンに移動する
        if (Application.loadedLevelName == "Game")
        {
            Application.LoadLevel("Menu");
        }
    }
}
