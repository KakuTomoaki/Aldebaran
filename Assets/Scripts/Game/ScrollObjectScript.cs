using UnityEngine;
using System.Collections;

public class ScrollObjectScript : MonoBehaviour {    

    public float speed = 1.0f;
    public float startPosition;
    public float endPosition;

    void Start() {
    }

    void Update() {
        //毎フレームxポジションを移動させる
        transform.Translate(1 * speed * Time.deltaTime, 0, 0);

        //スクロールの目標ポイントまで達成したかをチェック
        if (transform.position.x <= endPosition) ScrollEnd();
    }

    void ScrollEnd() {
        //スクロールする距離分を戻す
        transform.Translate(-1 * (endPosition - startPosition), 0, 0);

        //同じゲームオブジェクトにアタッチされているコンポーネントにメッセージを送る
        SendMessage("OnScrollEnd", SendMessageOptions.DontRequireReceiver);
    }
    
}