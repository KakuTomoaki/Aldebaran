using UnityEngine;
using System.Collections;

// X軸のみPlayerに合わせてScrollするScriptです

public class ScrollObject : MonoBehaviour {

    //プレイヤーのオブジェクトを格納する変数を宣言
    private GameObject player = null;

    void Start() {
        //プレイヤーを探しておく
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        //PlayerのX軸が0よりマイナスの際カメラのX軸をを0.0に固定 / Y軸は一番下の-3.8f
        if (player.transform.position.x <= 0.0) {
            transform.position = new Vector3(0.0f,
                                             0.0f,
                                             this.transform.position.z);
        }
        //PlayerのX軸が-2.0を上回ったらカメラ追従開始(+2.0f) / Y軸は一番下の-3.8f
        if (player.transform.position.x >= -2.0) {
            transform.position = new Vector3(player.transform.position.x + 2.0f,
                                             0.0f,
                                             this.transform.position.z);
        }

    }
}
