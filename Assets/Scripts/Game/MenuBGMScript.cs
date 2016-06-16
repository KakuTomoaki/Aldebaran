using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuBGMScript : MonoBehaviour {
    
    public static AudioSource MenuBGM;

    
    // このオブジェクト用の変数
    private static bool isCreatedObj = false;	// オブジェクト作成済みフラグ

    void Awake() {
        // 作成済みフラグがoffの場合
        if (isCreatedObj == false) {
            // シーンが切り替わってもオブジェクトを破棄しない
            DontDestroyOnLoad(this.gameObject);

            // 作成済みフラグをOnにする
            isCreatedObj = true;
            // 作成済みフラグがonの場合
        } else {
            // オブジェクトを破棄する
            Destroy(this.gameObject);
        }
    }

    // Use this for initialization
    void Start() {

        AudioSource[] audioSources = GetComponents<AudioSource>();
        MenuBGM = audioSources[0];
        MenuBGM.Play();
        GlobalVariableScript.isMenuBGM = true;

    }

    // Update is called once per frame
    void Update() {
        MenuBGM.volume = PlayerPrefs.GetFloat(GlobalVariableScript.BGMVolumePrefs, 1);
        if (SceneManager.GetActiveScene().name == "Game") {
            MenuBGM.Stop();
            GlobalVariableScript.isMenuBGM = false;
        }
        if (SceneManager.GetActiveScene().name == "Menu" && GlobalVariableScript.isMenuBGM == false) {
            MenuBGM.Play();
            GlobalVariableScript.isMenuBGM = true;
        }
    }

}