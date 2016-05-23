using UnityEngine;
using System.Collections;

public class ContinueNo : MonoBehaviour {

    //private RectTransform recttransform02;

    public void NextScene()
    {
        //今いるシーンがtestという名前であれば、testという名前のシーンに移動する
        if (Application.loadedLevelName == "Game")
        {
            ////ライフを最大値に戻す
            //GlobalVariableScript.PlayerLife = GlobalVariableScript.CnsPlayerLife;

            ////コインのバーをもとに戻す
            //GlobalVariableScript.BonusRedCoin = 0;

            ////保存されていたスコアをもとに戻す
            //GlobalVariableScript.ScoreSave = 0;

            //recttransform02 = GameObject.Find("Canvas/CoinBar02").GetComponent<RectTransform>();
            //recttransform02.sizeDelta = new Vector2(0, recttransform02.sizeDelta.y);

            //Application.LoadLevel(Application.loadedLevelName);

            Application.LoadLevel("Menu");
        }
    }
}
