using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameShareScript : MonoBehaviour {
    
    private AudioSource select;
    
    Text G_Score;

    void Start() {
        //SEをキャッシュ
        AudioSource[] audioSources = GetComponents<AudioSource>();
        select = audioSources[0];

        //スコアのセット
        G_Score = GameObject.Find("Canvas_Result/Score/Text").GetComponent<Text>();
        G_Score.text = Score.instance.score.ToString();
    }

    // シェア
    public void OnPushShare() {
        select.PlayOneShot(select.clip);
        // 画面をキャプチャ
        //Application.CaptureScreenshot("screenShot.png");

        // シェアテキスト設定
        string text = "Sonic Speed Breaker 1st." + G_Score.text + "！ この記録を抜けるかな？";
        string url = "http://google.com/";
        SocialConnector.Share(text, url);

        // キャプチャの保存先を指定
        //string texture_url = Application.persistentDataPath + "/screenShot.png";

        // iOS側の処理を呼び出す
        //SocialConnector.Share(text, url, texture_url);
        SocialConnector.Share(text, url);

    }

}