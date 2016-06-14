using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameBGMScript : MonoBehaviour {
    
    public static AudioSource GameBGM;

    private float waitTime = 3.0f;

    // Use this for initialization
    IEnumerator Start() {
        if(GlobalVariableScript.isCountDown == false) {
            yield return new WaitForSeconds(waitTime);

        }
        AudioSource[] audioSources = GetComponents<AudioSource>();
        GameBGM = audioSources[0];
		GameBGM.Play ();
        //GameBGM.PlayOneShot(GameBGM.clip);
        
    }

    // Update is called once per frame
    void Update() {
        if (GlobalVariableScript.isPause_BGM == true) {
            GameBGM.Pause();
        }
        if (GlobalVariableScript.isGameOver_BGM == true) {
            GameBGM.Stop();
        }
    }
    
}