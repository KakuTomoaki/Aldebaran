using UnityEngine;
using System.Collections;

public class ContinueNo : MonoBehaviour {

    public void NextScene()
    {
        //今いるシーンがtestという名前であれば、testという名前のシーンに移動する
        if (Application.loadedLevelName == "Game")
        {
            GlobalVariableScript.PlayerLife = GlobalVariableScript.CnsPlayerLife;       //ライフを最大値に戻す

            Application.LoadLevel(Application.loadedLevelName);
        }
    }
}
