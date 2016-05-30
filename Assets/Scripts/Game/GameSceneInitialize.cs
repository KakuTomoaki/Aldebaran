using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class GameSceneInitialize : MonoBehaviour {

    //表示用オブジェクト
    private Text text;
    private Image image;
    private GameObject canvas;

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

        //初期化（リトライ時の再呼び出しも考慮する）
        Time.timeScale = 1;                 // タイムスケール
        Score.instance.ScoreContinue();     // スコア

        text = GameObject.Find("Canvas/txtPlayerLife").GetComponent<Text>();
        text.text = "X" + GlobalVariableScript.PlayerLife.ToString();

        recttransform01 = GameObject.Find("Canvas/CoinBar01").GetComponent<RectTransform>();
        recttransform02 = GameObject.Find("Canvas/CoinBar02").GetComponent<RectTransform>();
        recttransform02.sizeDelta = new Vector2(recttransform01.sizeDelta.x * GlobalVariableScript.BonusRedCoin / GlobalVariableScript.CnsBounsRedCoin, recttransform02.sizeDelta.y);

        //キャンバスとオブジェクトの表示・非表示を切り替える
        canvas = GameObject.Find("Canvas");
        canvas.GetComponent<Canvas>().enabled = true;

        text = GameObject.Find("Canvas/CountDown").GetComponent<Text>();
        text.enabled = false;

        canvas = GameObject.Find("Canvas_Pause");
        canvas.GetComponent<Canvas>().enabled = false;

        canvas = GameObject.Find("Canvas_Continue");
        canvas.GetComponent<Canvas>().enabled = false;

        canvas = GameObject.Find("Canvas_Result");
        canvas.GetComponent<Canvas>().enabled = false;

        //ライフが最大（ゲーム初回起動、リトライ時）はカウントダウンへ突入
        if (GlobalVariableScript.PlayerLife == GlobalVariableScript.CnsPlayerLife)
        {
            image = GameObject.Find("Canvas/Pause").GetComponent<Image>();
            image.enabled = false;

            text = GameObject.Find("Canvas/CountDown").GetComponent<Text>();
            text.enabled = true;

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

    public void InitializeAll()
    {
        //タイムスケールを元に戻す
        Time.timeScale = 1;

        //カウントダウンフラグをおろす
        GlobalVariableScript.isCountDown = false;

        //足場の生成数をクリアする
        GlobalVariableScript.CreateCount = 0;

        //ライフを最大値に戻す
        GlobalVariableScript.PlayerLife = GlobalVariableScript.CnsPlayerLife;

        //コインのバーをもとに戻す
        GlobalVariableScript.BonusRedCoin = 0;

        //保存されていたスコアをもとに戻す
        GlobalVariableScript.ScoreSave = 0;

        recttransform02 = GameObject.Find("Canvas/CoinBar02").GetComponent<RectTransform>();
        recttransform02.sizeDelta = new Vector2(0, recttransform02.sizeDelta.y);
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
