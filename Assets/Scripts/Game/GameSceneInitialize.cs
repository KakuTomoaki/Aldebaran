using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameSceneInitialize : MonoBehaviour {

    //表示用オブジェクト
    private Text text;
    private Image image;

    private RectTransform recttransform01;
    private RectTransform recttransform02;

    // Use this for initialization
    void Start () {
        //初期化
        Score.instance.ScoreContinue();

        text = GameObject.Find("Canvas/txtPlayerLife").GetComponent<Text>();
        text.text = "X" + GlobalVariableScript.PlayerLife.ToString();

        recttransform01 = GameObject.Find("Canvas/CoinBar01").GetComponent<RectTransform>();
        recttransform02 = GameObject.Find("Canvas/CoinBar02").GetComponent<RectTransform>();
        recttransform02.sizeDelta = new Vector2(recttransform01.sizeDelta.x * GlobalVariableScript.BonusRedCoin / GlobalVariableScript.CnsBounsRedCoin, recttransform02.sizeDelta.y);

        //表示を隠す
        text = GameObject.Find("Canvas/TxtContinue").GetComponent<Text>();
        text.enabled = false;

        image = GameObject.Find("Canvas/BtnContnueYes").GetComponent<Image>();
        image.enabled = false;
        text = GameObject.Find("Canvas/BtnContnueYes/Text").GetComponent<Text>();
        text.enabled = false;

        image = GameObject.Find("Canvas/BtnContinueNo").GetComponent<Image>();
        image.enabled = false;
        text = GameObject.Find("Canvas/BtnContinueNo/Text").GetComponent<Text>();
        text.enabled = false;

        //タイムスケール
        Time.timeScale = 1;
    }
}
