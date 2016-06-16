using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameShareScript : MonoBehaviour {
    
    private AudioSource select;
    private bool isShare = false;
    
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

        Debug.Log("Share Tap！");
        // シェアテキスト設定
        string text = "Sonic Speed Breaker Score:" + G_Score.text + "！";
        string url = "http://google.com/";
        SocialConnector.Share(text, url);

    }

}