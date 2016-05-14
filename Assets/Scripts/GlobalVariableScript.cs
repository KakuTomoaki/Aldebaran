using UnityEngine;
using System.Collections;

public class GlobalVariableScript : MonoBehaviour {

    public const string BGMVolumePrefs = "BGMVolume";   //Music Volumeのデータを書き込むPlayerPrefs
    public const string SEVolumePrefs = "SEVolume"; //Effect Volumeのデータを書き込むPlayerPrefs

    //プレイヤーのステータス
    public const int MoveSpeedDefault = 6;      //デフォルトの横移動速度

    public static int moveSpeed = MoveSpeedDefault;         // ユニティちゃんの移動速度
    public static float timer = 0;                          // 秒数
    public static bool isCountDown = false;					// カウントダウンするかのフラグ
    public static bool isGameOver_BGM = false;              // GameOver時、BGMの再生停止のフラグ
    public static bool isPause_BGM = false;                 // Pause時、BGMの一時停止のフラグ

    //コイン
    public static int CoinYellowPoint = 1;                  // 黄色コインをとったときに増えるポイント
    public static int CoinBluePoint = 10;                   // 青色コインをとったときに増えるポイント
    public static int CoinRedPoint = 100;                   // 赤色コインをとったときに増えるポイント

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
