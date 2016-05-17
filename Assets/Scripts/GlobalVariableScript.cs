using UnityEngine;
using System.Collections;

public class GlobalVariableScript : MonoBehaviour {

    //ゲームシーンで利用する変数
    public static int CreateCount = 0;  //呼びだされたobjectの数

    public const string BGMVolumePrefs = "BGMVolume";   //Music Volumeのデータを書き込むPlayerPrefs
    public const string SEVolumePrefs = "SEVolume"; //Effect Volumeのデータを書き込むPlayerPrefs

    //プレイヤーのステータス
    public static int moveSpeed = 6;                        // ユニティちゃんの移動速度
    public static int PlayerLife = 3;                       // ユニティちゃんのライフ
    public static float timer = 0;                          // 秒数
    public static bool isCountDown = false;					// カウントダウンするかのフラグ
    public static bool isGameOver_BGM = false;              // GameOver時、BGMの再生停止のフラグ
    public static bool isPause_BGM = false;                 // Pause時、BGMの一時停止のフラグ

    //コイン
    public static int CoinYellowPoint = 100;                  // 黄色コインをとったときに増えるポイント
    public static int CoinBluePoint = 500;                   // 青色コインをとったときに増えるポイント
    public static int CoinRedPoint = 1000;                   // 赤色コインをとったときに増えるポイント

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
