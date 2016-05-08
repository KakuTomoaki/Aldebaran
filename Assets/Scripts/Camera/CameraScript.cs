using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    private Camera cam;
    // 画像のサイズ
    private float width = 1280f;
    private float height = 720f;
    // 画像のPixel Per Unit
    private float pixelPerUnit = 100f;

    //プレイヤーのオブジェクトを格納する変数を宣言
    private GameObject player = null;

    void Awake() {
        float aspect = (float)Screen.height / (float)Screen.width;
        float bgAcpect = height / width;

        // カメラコンポーネントを取得します
        cam = GetComponent<Camera>();
        // カメラのorthographicSizeを設定
        cam.orthographicSize = (height / 2f / pixelPerUnit);


        if (bgAcpect > aspect) {
            // 倍率
            float bgScale = height / Screen.height;
            // viewport rectの幅
            float camWidth = width / (Screen.width * bgScale);
            // viewportRectを設定
            cam.rect = new Rect((1f - camWidth) / 2f, 0f, camWidth, 1f);
        } else {
            // 倍率
            float bgScale = width / Screen.width;
            // viewport rectの幅
            float camHeight = height / (Screen.height * bgScale);
            // viewportRectを設定
            cam.rect = new Rect(0f, (1f - camHeight) / 2f, 1f, camHeight);
        }

    }

    void Start() {
        //プレイヤーを探しておく
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        //PlayerのX軸が0よりマイナスの際カメラのX軸をを0.0に固定、Y軸は0.0
        if (player.transform.position.x <= 0.0) {
            transform.position = new Vector3(0.0f,
                                             0.0f,
                                             this.transform.position.z);
        }
        //PlayerのX軸が-2.0を上回ったらカメラ追従開始(+2.0f)
        if (player.transform.position.x >= -2.0) {
            transform.position = new Vector3(player.transform.position.x + 2.0f,
                                             0.0f,
                                             this.transform.position.z);
        }
    }
}