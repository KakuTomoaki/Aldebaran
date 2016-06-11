using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using NendUnityPlugin.AD;

public class PlayerScript : MonoBehaviour {

    Rigidbody2D rb;
    Animator anim;

    //ジャンプ関連
    public LayerMask groundLayer;//地面のレイヤー

    bool isGrounded;            //着地しているかの判定
    bool isNotSideFloor_Up;     //フロア関連
    bool isInput;               //ジャンプを受け付けるかの判定

    private static int restJumps = 2;     //ジャンプ回数
    private float jumpHeight_1 = 1.8f;    //レベルデザインで数値変更よろす
    private float jumpHeight_2 = 1.2f;    //レベルデザインで数値変更よろす

    //音関連
    private AudioSource SE_Jump;
    private AudioSource SE_Landing;
    private AudioSource SE_Fall;
    private AudioSource SE_Bom;
    private AudioSource Jump_01;
    private AudioSource Jump_02;
    private AudioSource GameOver002;
    private AudioSource GameClear002;
    private AudioSource SE_SpeedUp;

    //リザルト関連
    private GameObject gameobject;
	private bool isCleard = false;
    private bool isContinue = false;
	private bool isGameOver = false;
	private bool isScoreSaveEnd = false;

    //表示用オブジェクト
    Text text;
    Image image;

    //キャンバス
    private GameObject canvas_pause;
    private GameObject canvas_continue;
    private GameObject canvas_relust;

    void Start() {
        rb = GetComponent<Rigidbody2D>(); //GetComponentの処理をキャッシュしておく
        anim = GetComponent<Animator>(); //Animatorをキャッシュ

        //SEをキャッシュ
        AudioSource[] audioSources = GetComponents<AudioSource>();
        SE_Jump = audioSources[0];
        SE_Landing = audioSources[1];
        SE_Fall = audioSources[2];
        SE_Bom = audioSources[3];
        Jump_01 = audioSources[4];
        Jump_02 = audioSources[5];
        SE_SpeedUp = audioSources[6];

        //キャンバスをキャッシュ
        canvas_pause = GameObject.Find("Canvas_Pause");
        canvas_continue = GameObject.Find("Canvas_Continue");
        canvas_relust = GameObject.Find("Canvas_Result");

#if UNITY_IPHONE
NendAdInterstitial.Instance.Load("iOS apiKey", "iOS spotId");
#elif UNITY_ANDROID
        NendAdInterstitial.Instance.Load("9bebab59eff92c6188651412e4c3a137774eaeaf", "608647");
#else
#endif
    }

    //Updateだとクリックを判定できない時があるため、
    //ジャンプの処理はUpdateメソッドに記述
    void Update() {
        if(GlobalVariableScript.isCountDown == false) {
            anim.SetBool("Stay", true);
            return;
        } else if(GlobalVariableScript.isCountDown == true) {
            anim.SetBool("Run", true);
        }
        
        if (GlobalVariableScript.isSE_SpeedUp == true) {
            SE_SpeedUp.PlayOneShot(SE_SpeedUp.clip);
            GlobalVariableScript.isSE_SpeedUp = false;
        }
        //クリアしたかどうかの判定を追加
        //終了処理は一度だけ呼ぶ
        /*
        if (isScoreSaveEnd == false) {
			if (GlobalVariableScript.Gamemode == GlobalVariableScript.GamemodeFloor10) {
				//Floor10のゴール階数に到達した場合クリアフラグを立てる
				if(GlobalVariableScript.FloorCount == GlobalVariableScript.Floor10Goal) isCleard = true;
			} else if (GlobalVariableScript.Gamemode == GlobalVariableScript.GamemodeFloor20) {
				//Floor20のゴール階数に到達した場合クリアフラグを立てる
				if(GlobalVariableScript.FloorCount == GlobalVariableScript.Floor20Goal) isCleard = true;
			} else if (GlobalVariableScript.Gamemode == GlobalVariableScript.GamemodeFloor30) {
				//Floor30のゴール階数に到達した場合クリアフラグを立てる
				if(GlobalVariableScript.FloorCount == GlobalVariableScript.Floor30Goal) isCleard = true;
			} 


			// クリアフラグが立っていた場合
			if (isCleard == true) {
				//anim.speed = 0;                       		// アニメーション停止
				rb.isKinematic = true;
				restJumps = 0;                        		// ジャンプ回数0
				GlobalVariableScript.moveSpeed = 0;   		// 移動速度0
				GlobalVariableScript.isCountDown = false;	// カウントダウン停止

				//データセーブ処理呼び出し
				ResultEdit = GameObject.Find ("ResultEdit");
				ResultEdit.SendMessage ("ResultClear");
				isScoreSaveEnd = true;
                
			}
		}

        */

        //Menuのいずれかが表示されていた場合は、入力をうけつけない
        isInput = true;

        if(canvas_pause.GetComponent<Canvas>().enabled == true ||
           canvas_continue.GetComponent<Canvas>().enabled == true ||
           canvas_relust.GetComponent<Canvas>().enabled == true)
        {
            isInput = false;
        }

        if (isInput == true)
        {
            //ユニティちゃん中央から足元にかけて、接地判定用のラインを引く
            isGrounded = Physics2D.Linecast(
            transform.position + transform.up * 1,
            transform.position - transform.up * 0.1f,
            groundLayer); // Linecastが判定するレイヤー

            //スマートフォン用
            if (Input.touchCount > 0) {
                /*
                if (GlobalVariableScript.isCountDown == false) {    //カウントダウン時は操作を受け付けない ※一旦保留
                    return;
                }
                */
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began) {
                    if (restJumps > 0) {
                        if (isGrounded == false) {
                            restJumps = 1;
                        }
                        Jump();
                    }
                }
            }

            //PC版用
            if (Input.GetButtonDown("Jump")) {
                /*
                if (GlobalVariableScript.isCountDown == false) {    //カウントダウン時は操作を受け付けない ※一旦保留
                    return;
                }
                */
                if (restJumps > 0) {
                    if (isGrounded == false) {
                        restJumps = 1;
                    }
                    Jump();
                }
            }
            Anim();
        }
    }


    // Update is called once per frame
    void FixedUpdate() {
        //velocity:速度
        //X方向へmoveSpeed分移動させる
		rb.velocity = new Vector2(transform.localScale.x * GlobalVariableScript.moveSpeed,
            rb.velocity.y);

    }

    void OnCollisionEnter2D(Collision2D col) { // 2Dの衝突判定
      
        if (col.gameObject.tag == "Floor") {
            restJumps = 2; //ジャンプ回数リセット
            SE_Landing.PlayOneShot(SE_Landing.clip); // 着地音再生
        }
        
        if (col.gameObject.tag == "DeadZone") {
            SE_Fall.PlayOneShot(SE_Fall.clip);                // 落下音再生
            
            //画面停止する
            Time.timeScale = 0;

            //ライフを1へらす
            GlobalVariableScript.PlayerLife = GlobalVariableScript.PlayerLife - 1;

            //ライフが残っていた場合
            if (GlobalVariableScript.PlayerLife >= 0)
            {
                //コンティニュー処理を呼び出す
                Continue();
            }
            else
            {
                //ゲームオーバー処理を呼び出す
                GameOver();
            }
        }
        
        if (col.gameObject.tag == "Spike") {
            SE_Bom.PlayOneShot(SE_Bom.clip);                  // 爆発音再生

            //ライフを1へらす
            GlobalVariableScript.PlayerLife = GlobalVariableScript.PlayerLife - 1;

            //ライフが残っていた場合
            if (GlobalVariableScript.PlayerLife >= 0)
            {
                //コンティニュー処理を呼び出す
                Continue();
            }
            else
            {
                //ゲームオーバー処理を呼び出す
                GameOver();
            }
        }

        /*
		// ゲームオーバーだった場合
		if (isGameOver == true) {
			// カウントダウン停止
			GlobalVariableScript.isCountDown = false;	

			//データ表示処理呼び出し
			ResultEdit = GameObject.Find ("ResultEdit");
			ResultEdit.SendMessage ("ResultGameOver");
		}
        */
    }

    //Continueメソッド
    void Continue() {
        //Pause Buttonを無効化
        GameObject.Find("Canvas/Pause").GetComponent<Button>().interactable = false;

        //コンティニューのオブジェクトを表示する
        canvas_continue.GetComponent<Canvas>().enabled = true;
    }

    //GameOverメソッド
    void GameOver() {
        //        if (GlobalVariableScript.PlayerLife == 0) {
        //isGameOver = true;
        //anim.speed = 0;
        //rb.velocity = Vector2.zero;
        //rb.isKinematic = true;
        //restJumps = 0;                                      // ジャンプ回数0
        //GlobalVariableScript.moveSpeed = 0;                 // 移動速度0

        GlobalVariableScript.isGameOver_BGM = true;         // BGM再生停止フラグON

        //初期化フラグをたてる
        GlobalVariableScript.isInitializeAll = true;

        //リザルトを表示
        gameobject = GameObject.Find("Result");
        gameobject.SendMessage("ShowResult");

        //広告を表示
        NendAdInterstitial.Instance.Show();
        Debug.Log("広告表示");

        //        }
        //        else {
        //            return;
        //        }
    }

    //Jumpメソッド
    void Jump() {

        anim.SetTrigger("Jump");   //ジャンプアニメーションの開始

        SE_Jump.PlayOneShot(SE_Jump.clip);    //ジャンプSEの再生

        if (restJumps == 2) {    //初回ジャンプ時の動作
            Jump_01.PlayOneShot(Jump_01.clip);    //ジャンプボイスの再生
            float gravity = Mathf.Abs(Physics.gravity.y);
            float velocity = Mathf.Sqrt(2 * gravity * jumpHeight_1);
            this.rb.velocity = Vector3.up * velocity;
            restJumps--;
        } else if (restJumps == 1) {    //二段ジャンプ時の動作
            Jump_02.PlayOneShot(Jump_02.clip);    //ジャンプボイスの再生
            float gravity = Mathf.Abs(Physics.gravity.y);
            float velocity = Mathf.Sqrt(2 * gravity * jumpHeight_2);
            this.rb.velocity = Vector3.up * velocity;
            restJumps--;
        }
        isGrounded = false; //地面から離れるのでfalseにする

    }

    void Anim() {
        //velY:y方向へ掛かる速度単位、上へ行くとプラス、下へ行くとマイナス
        float velY = rb.velocity.y;
        //Animatorへパラメーターを送る
        anim.SetFloat("velY", velY);
        anim.SetBool("isGrounded", isGrounded);

    }
    
}
