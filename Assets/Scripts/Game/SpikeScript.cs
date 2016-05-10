using UnityEngine;
using System.Collections;

public class SpikeScript : MonoBehaviour {

    //エフェクトのプレハブへのパス
    private const string EFFECT_PATH = "Prefab/Spike_Anim";

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {    // Playerタグの付いたオブジェクトと衝突
            foreach (ContactPoint2D point in collision.contacts) {
                GameObject effect = Instantiate(Resources.Load(EFFECT_PATH)) as GameObject;
                effect.transform.position = (Vector3)point.point;
                Destroy(effect, 0.4f);
            }
        }
    }
}
