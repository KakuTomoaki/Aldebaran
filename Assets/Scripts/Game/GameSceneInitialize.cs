using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class GameSceneInitialize : MonoBehaviour {

    //表示用オブジェクト
    //private Text text;
    //private Image image;

    private GameObject canvas;
    private Text mCountDown;
    private RectTransform recttransform01;
    private RectTransform recttransform02;

    private int movespeedbuf;   // 一時保存用Unityちゃんの速度

    public AudioSource CountDown3Voice;     // 3秒前ボイス
    public AudioSource CountDown2Voice;     // 2秒前ボイス
    public AudioSource CountDown1Voice;     // 1秒前ボイス
    public AudioSource CountDownStartVoice; // スタートボイス

    // Use this for initialization
    void Start () {
        //キャンバスとオブジェクトの表示・非表示を切り替える
        canvas = GameObject.Find("Canvas");
        canvas.GetComponent<Canvas>().enabled = true;

        GameObject.Find("Canvas/CountDown").GetComponent<Text>().enabled = false;

        canvas = GameObject.Find("Canvas_Pause");
        canvas.GetComponent<Canvas>().enabled = false;

        canvas = GameObject.Find("Canvas_Continue");
        canvas.GetComponent<Canvas>().enabled = false;

        canvas = GameObject.Find("Canvas_Result");
        canvas.GetComponent<Canvas>().enabled = false;

        //初期化フラグが立っている（ゲームを最初の状態からプレイする）時
        if (GlobalVariableScript.isInitializeAll == true){
            //初期化フラグをおろす
            GlobalVariableScript.isInitializeAll = false;
 
            //各種データを初期化
            Time.timeScale = 1;                                                         //タイムスケールを元に戻す
            GlobalVariableScript.isCountDown = false;                                   //カウントダウンフラグをおろす
            GlobalVariableScript.CreateCount = 0;                                       //足場の生成数をクリアする
            GlobalVariableScript.PlayerLife = GlobalVariableScript.CnsPlayerLife;       //ライフを最大値に戻す
            GlobalVariableScript.BonusRedCoin = 0;                                      //コインのバーをもとに戻す
            GlobalVariableScript.ScoreSave = 0;                                         //保存されていたスコアをもとに戻す
            GlobalVariableScript.moveSpeed = GlobalVariableScript.MoveSpeedDefault;     //スピードをデフォルトに戻す

            //コインバーを再描画
            recttransform02 = GameObject.Find("Canvas/CoinBar02").GetComponent<RectTransform>();
            recttransform02.sizeDelta = new Vector2(0, recttransform02.sizeDelta.y);

            //ライフを表示
            GameObject.Find("Canvas/txtPlayerLife").GetComponent<Text>().text = "X" + GlobalVariableScript.PlayerLife.ToString();

            //Pause Buttonを無効化
            GameObject.Find("Canvas/Pause").GetComponent<Button>().interactable = false;

            //カウントダウンを非表示
            GameObject.Find("Canvas/CountDown").GetComponent<Text>().enabled = true;

            //Unityちゃんのスピードを一時保存し、0にする
            movespeedbuf = GlobalVariableScript.moveSpeed;
            GlobalVariableScript.moveSpeed = 0;

            //mAudio = GetComponent<AudioSource> ();
            AudioSource[] mAudio = GetComponents<AudioSource>();
            CountDown3Voice = mAudio[0];
            CountDown2Voice = mAudio[1];
            CountDown1Voice = mAudio[2];
            CountDownStartVoice = mAudio[3];

            // カウントダウンのコルーチンを呼び出す
            mCountDown = GameObject.Find("Canvas/CountDown").GetComponent<Text>();
            StartCoroutine(CountdownCoroutine());
        }
        else
        {
            Time.timeScale = 1;                 // タイムスケール
            Score.instance.ScoreContinue();     // スコア

            //ライフを再描画
            GameObject.Find("Canvas/txtPlayerLife").GetComponent<Text>().text = "X" + GlobalVariableScript.PlayerLife.ToString();

            //コインバーを再描画
            recttransform01 = GameObject.Find("Canvas/CoinBar01").GetComponent<RectTransform>();
            recttransform02 = GameObject.Find("Canvas/CoinBar02").GetComponent<RectTransform>();
            recttransform02.sizeDelta = new Vector2(recttransform01.sizeDelta.x * GlobalVariableScript.BonusRedCoin / GlobalVariableScript.CnsBounsRedCoin, recttransform02.sizeDelta.y);
        }
    }

    IEnumerator CountdownCoroutine()
    {
        mCountDown.text = "3";
        CountDown3Voice.PlayOneShot(CountDown3Voice.clip);
        yield return new WaitForSeconds(1.0f);

        mCountDown.text = "2";
        CountDown2Voice.PlayOneShot(CountDown2Voice.clip);
        yield return new WaitForSeconds(1.0f);

        mCountDown.text = "1";
        CountDown1Voice.PlayOneShot(CountDown1Voice.clip);
        yield return new WaitForSeconds(1.0f);

        mCountDown.text = "GO";
        CountDownStartVoice.PlayOneShot(CountDownStartVoice.clip);

        //Pause Buttonを有効化
        GameObject.Find("Canvas/Pause").GetComponent<Button>().interactable = true;

        // カウントダウンフラグをオンにする
        GlobalVariableScript.isCountDown = true;

        // ユニティちゃんのスピードを元に戻す
        GlobalVariableScript.moveSpeed = movespeedbuf;

        yield return new WaitForSeconds(1.0f);
        mCountDown.text = "";
    }
}
