using UnityEngine;
using System.Collections;

public class Retry : MonoBehaviour {

    private GameObject GameSceneInitialize;

    public void NextScene()
    {
        if (Application.loadedLevelName == "Game")
        {
            GameSceneInitialize = GameObject.Find("Initialize");
            GameSceneInitialize.SendMessage("InitializeAll");

            Application.LoadLevel(Application.loadedLevelName);
        }
    }
}
