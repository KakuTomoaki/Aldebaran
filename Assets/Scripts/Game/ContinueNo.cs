using UnityEngine;
using System.Collections;

public class ContinueNo : MonoBehaviour {

    //private RectTransform recttransform02;
    private GameObject GameSceneInitialize;

    public void NextScene()
    {
        //今いるシーンがtestという名前であれば、testという名前のシーンに移動する
        if (Application.loadedLevelName == "Game")
        {
            //GameSceneInitialize = GameObject.Find("Initialize");
            //GameSceneInitialize.SendMessage("InitializeAll");
            //初期化フラグをたてる
            GlobalVariableScript.isInitializeAll = true;

            Application.LoadLevel("Menu");
        }
    }
}
