using UnityEngine;
using System.Collections;
/*
* スコアを管理するクラス
*/
public class Score : MonoBehaviour {
	// Scoreクラスの唯一のインスタンス
	private static Score mInstance;
	
	/*
    *Scoreのインスタンスを返す関数
    *(staticでpublicなので、どのソースコードからでも呼ぶことができる)
    */
	public static Score instance{
		get{
			//インスタンスが参照されているか
			if(mInstance == null){
				//インスタンスを探し、参照する
				mInstance = FindObjectOfType<Score>();
			}
			//インスタンスを返す
			return mInstance;
		}
	}
	
	/*
     *  はじめに呼ばれる関数
     */
	public void Start(){
		//インスタンスがこれ自身でなければ消す
		if (this != instance) {
			Destroy(this);
		}
	}
	
	//スコア
	public int score{
		get;
		//setはこのソースコードからしか呼ばれないようにする
		private set;
	}
	/*
    *黄色コインをとったときの処理
    */
	public void Add_Yellow(){
		score = score + GlobalVariableScript.CoinYellowPoint;
	}

    /*
    *青色コインをとったときの処理
    */
    public void Add_Blue()
    {
        score = score + GlobalVariableScript.CoinBluePoint;
    }

    /*
    *赤色コインをとったときの処理
    */
    public void Add_Red()
    {
        score = score + GlobalVariableScript.CoinRedPoint;
    }

    /*
    *スコアを0にする関数
    */
    public void Reset(){
		score = 0;
	}
}