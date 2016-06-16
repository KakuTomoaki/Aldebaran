using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//AudioSourceを必要とする
//これを記述しておくとこのコンポーネントを追加した際に
//一緒にAudioSorceコンポーネントも追加される
[RequireComponent(typeof(AudioSource))]

/*
 * Coinクラス
 * 
 * Playerに当たった時に音を鳴らす
 * 
 */
public class Coin_Red : MonoBehaviour {


    private AudioSource mAudio;
    private Renderer mRenderer;
    private Collider2D mCollider2D;

    private float CoinBarWidth;
    private float CoinBarHeight;

    private RectTransform recttransform01;
    private RectTransform recttransform02;

    /*
	 * はじめに呼ばれる関数
	 */
    void Start()
    {
        //必要なコンポーネントを取得する
        mAudio = GetComponent<AudioSource>();
        mRenderer = GetComponent<Renderer>();
        mCollider2D = GetComponent<Collider2D>();

        recttransform01 = GameObject.Find("Canvas/CoinBar01").GetComponent<RectTransform>();
        recttransform02 = GameObject.Find("Canvas/CoinBar02").GetComponent<RectTransform>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //もし 接触したオブジェクトのタグが"Player"なら
        if (other.tag == "Player")
        {
            Score.instance.Add_Red();

            //コインの取得枚数を増やす
            GlobalVariableScript.BonusRedCoin = GlobalVariableScript.BonusRedCoin + 1;

            //赤コインが10枚になったらボーナスフラグを立てて枚数をリセット
            if(GlobalVariableScript.BonusRedCoin == 10)
            {
                GlobalVariableScript.BonusFlag = true;
                GlobalVariableScript.BonusRedCoin = 0;
            }
            //コインバーの表示を変更
            recttransform02.sizeDelta = new Vector2(recttransform01.sizeDelta.x * GlobalVariableScript.BonusRedCoin/ GlobalVariableScript.CnsBounsRedCoin, recttransform02.sizeDelta.y);

            //描画を消す
            mRenderer.enabled = false;
            //当たりを消す
            mCollider2D.enabled = false;

            //音を再生する
            mAudio.volume = PlayerPrefs.GetFloat(GlobalVariableScript.SEVolumePrefs, 1);
            mAudio.Play();
            //音が流れ終わると消える
            Destroy(gameObject, mAudio.clip.length);
        }
    }

}
