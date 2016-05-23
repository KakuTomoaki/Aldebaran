using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class GameSceneInitialize : MonoBehaviour {

    //表示用オブジェクト
    private Text text;
    private Image image;

    private RectTransform recttransform01;
    private RectTransform recttransform02;

    private int movespeedbuf;   // 一時保存用Unityちゃんの速度

    private Text mCountDown;

    public AudioSource CountDown3Voice;     // 3秒前ボイス
    public AudioSource CountDown2Voice;     // 2秒前ボイス
    public AudioSource CountDown1Voice;     // 1秒前ボイス
    public AudioSource CountDownStartVoice; // スタートボイス

    // Use this for initialization
    void Start () {

        //初期化
        Time.timeScale = 1;                 // タイムスケール
        Score.instance.ScoreContinue();     // スコア
//        GlobalVariableScript.moveSpeed = GlobalVariableScript.MoveSpeedDefault;		//移動速度をデフォルトに

        text = GameObject.Find("Canvas/txtPlayerLife").GetComponent<Text>();
        text.text = "X" + GlobalVariableScript.PlayerLife.ToString();

        recttransform01 = GameObject.Find("Canvas/CoinBar01").GetComponent<RectTransform>();
        recttransform02 = GameObject.Find("Canvas/CoinBar02").GetComponent<RectTransform>();
        recttransform02.sizeDelta = new Vector2(recttransform01.sizeDelta.x * GlobalVariableScript.BonusRedCoin / GlobalVariableScript.CnsBounsRedCoin, recttransform02.sizeDelta.y);

        //表示
        image = GameObject.Find("Canvas/Pause").GetComponent<Image>();
        image.enabled = true;

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

        image = GameObject.Find("Canvas/Pause_Continue").GetComponent<Image>();
        image.enabled = false;
        text = GameObject.Find("Canvas/Pause_Continue/Text").GetComponent<Text>();
        text.enabled = false;

        image = GameObject.Find("Canvas/Pause_Retry").GetComponent<Image>();
        image.enabled = false;
        text = GameObject.Find("Canvas/Pause_Retry/Text").GetComponent<Text>();
        text.enabled = false;

        image = GameObject.Find("Canvas/Pause_TopMenu").GetComponent<Image>();
        image.enabled = false;
        text = GameObject.Find("Canvas/Pause_TopMenu/Text").GetComponent<Text>();
        text.enabled = false;

        if (GlobalVariableScript.PlayerLife == GlobalVariableScript.CnsPlayerLife)
        {
            image = GameObject.Find("Canvas/Pause").GetComponent<Image>();
            image.enabled = false;

            movespeedbuf = GlobalVariableScript.moveSpeed;
            GlobalVariableScript.moveSpeed = 0;

            //mAudio = GetComponent<AudioSource> ();
            AudioSource[] mAudio = GetComponents<AudioSource>();
            CountDown3Voice = mAudio[0];
            CountDown2Voice = mAudio[1];
            CountDown1Voice = mAudio[2];
            CountDownStartVoice = mAudio[3];

            mCountDown = GameObject.Find("Canvas/CountDown").GetComponent<Text>();

            // カウントダウンのコルーチンを呼び出す
            StartCoroutine(CountdownCoroutine());
        }
    }

    IEnumerator CountdownCoroutine()
    {

        Debug.Log("CountDown3");

        mCountDown.text = "3";
        CountDown3Voice.PlayOneShot(CountDown3Voice.clip);
        yield return new WaitForSeconds(1.0f);

        Debug.Log("CountDown2");

        mCountDown.text = "2";
        CountDown2Voice.PlayOneShot(CountDown2Voice.clip);
        yield return new WaitForSeconds(1.0f);

        mCountDown.text = "1";
        CountDown1Voice.PlayOneShot(CountDown1Voice.clip);
        yield return new WaitForSeconds(1.0f);

        mCountDown.text = "GO";
        CountDownStartVoice.PlayOneShot(CountDownStartVoice.clip);

        // 一時停止ボタンを表示させる
        image = GameObject.Find("Canvas/Pause").GetComponent<Image>();
        image.enabled = true;

        // カウントダウンフラグをオンにする
        GlobalVariableScript.isCountDown = true;

        // ユニティちゃんのスピードを元に戻す
        GlobalVariableScript.moveSpeed = movespeedbuf;

        yield return new WaitForSeconds(1.0f);
        mCountDown.text = "";
    }
}
