using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameStartScript : MonoBehaviour {

    private AudioSource select;
    private float Next_in_Time = 1f;       //次のシーンへ遷移するまでの時間
    private float SE_WaitTime = 0.25f;    //フェードインが始まるまでの時間

    void Start()
    {
        //SEをキャッシュ
        AudioSource[] audioSources = GetComponents<AudioSource>();
        select = audioSources[0];
    }

    public void NextScene()
    {
        select.volume = PlayerPrefs.GetFloat(GlobalVariableScript.SEVolumePrefs, 1);
        select.PlayOneShot(select.clip);
        StartCoroutine("Wait_Time");
    }

    IEnumerator Wait_Time()
    {
        yield return new WaitForSeconds(SE_WaitTime);
        CameraFade.StartAlphaFade(Color.black, false, Next_in_Time, SE_WaitTime, () => { SceneManager.LoadScene("Game"); });
    }
}
