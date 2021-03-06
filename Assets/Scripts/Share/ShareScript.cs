﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShareScript : MonoBehaviour {

    private AudioSource select;
    private float SE_WaitTime = 0.2f;

    float S_Score;

    void Start() {
        //SEをキャッシュ
        AudioSource[] audioSources = GetComponents<AudioSource>();
        select = audioSources[0];
        
        //スコアのセット
        S_Score = PlayerPrefs.GetFloat(GlobalVariableScript.Prefs_Score1st, 0);
    }

    // シェア
    public void OnPushShare() {
        StartCoroutine(Share());
    }

    // シェア処理
    private IEnumerator Share() {
        select.PlayOneShot(select.clip);

        // キャプチャを保存するので１フレーム待つ
        yield return new WaitForSeconds(SE_WaitTime);
        
        // シェアテキスト設定
        string text = "Sonic Speed Breaker 1st." + S_Score + "！ この記録を抜けるかな？";
        string url = "http://google.com/";
        SocialConnector.Share(text, url);
    
    }
}