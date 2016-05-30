using UnityEngine;
using System.Collections;

public class GlobalVariableScript : MonoBehaviour {

    /********************************
    * 定数
    ********************************/
    //PlayerPrefs関連
    public const string BGMVolumePrefs = "BGMVolume";       //Music Volumeのデータを書き込むPlayerPrefs
    public const string SEVolumePrefs = "SEVolume";         //Effect Volumeのデータを書き込むPlayerPrefs

    //プレイヤー関連
    public const int CnsPlayerLife = 3;                     //ユニティちゃんのライフの最大値
    public const int CnsBounsRedCoin = 10;                   //ボーナスステージに突入するまでの赤コインの数
    public const int MoveSpeedDefault = 6;		            //デフォルトの横移動速度

    //コイン
    public const int CoinYellowPoint = 100;                 // 黄色コインをとったときに増えるポイント
    public const int CoinBluePoint = 500;                   // 青色コインをとったときに増えるポイント
    public const int CoinRedPoint = 1000;                   // 赤色コインをとったときに増えるポイント

    //データ保存関連
    public const string Prefs_Score1st = "Prefs_Score1st";   //1位のデータを書き込むPlayerPrefs	
    public const string Prefs_Score2nd = "Prefs_Score2nd";   //2位のデータを書き込むPlayerPrefs	
    public const string Prefs_Score3rd = "Prefs_Score3rd";	 //3位のデータを書き込むPlayerPrefs	

    /********************************
    * 変数
    ********************************/
    //ゲームシーンで利用する変数
    public static int CreateCount = 0;                      //呼びだされたobjectの数
    public static int BonusRedCoin = 0;                     //赤コインの取得数
    public static int ScoreSave = 0;                        //再呼び出し用スコア

    //プレイヤーのステータス
    public static int moveSpeed = MoveSpeedDefault;         // ユニティちゃんの移動速度
    public static int PlayerLife = CnsPlayerLife;           // ユニティちゃんのライフの現在の値
    public static float timer = 0;                          // 秒数
    public static bool isCountDown = false;					// カウントダウンするかのフラグ
    public static bool isGameOver_BGM = false;              // GameOver時、BGMの再生停止のフラグ
    public static bool isPause_BGM = false;                 // Pause時、BGMの一時停止のフラグ
    public static bool isSE_SpeedUp = false;                // スピードアップSE再生のフラグ

    // このオブジェクト用の変数
    private static bool isCreatedObj = false;   // オブジェクト作成済みフラグ

    void Awake()
    {
        // 作成済みフラグがoffの場合
        if (isCreatedObj == false)
        {
            // シーンが切り替わってもオブジェクトを破棄しない
            DontDestroyOnLoad(this.gameObject);

            // 作成済みフラグをOnにする
            isCreatedObj = true;
            // 作成済みフラグがonの場合
        }
        else {
            // オブジェクトを破棄する
            Destroy(this.gameObject);
        }
    }
}
