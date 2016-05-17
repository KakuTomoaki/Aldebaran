using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameSceneInitialize : MonoBehaviour {

    //表示用オブジェクト
    Text text;
    Image image;

    // Use this for initialization
    void Start () {
        //変数の初期化

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
