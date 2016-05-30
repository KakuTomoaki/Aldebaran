using UnityEngine;
using System.Collections;

public class TopMenu : MonoBehaviour {

    private GameObject GameSceneInitialize;

    public void NextScene()
    {
        //今いるシーンがtestという名前であれば、testという名前のシーンに移動する
        if (Application.loadedLevelName == "Game")
        {
            GameSceneInitialize = GameObject.Find("Initialize");
            GameSceneInitialize.SendMessage("InitializeAll");

            Application.LoadLevel("Menu");
        }
    }
}
