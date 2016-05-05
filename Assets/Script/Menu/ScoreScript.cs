using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScoreScript : MonoBehaviour
{

    private AudioSource select;
    private float SE_WaitTime = 0.25f;

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
        SceneManager.LoadScene("Score");
    }
}