using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartScript : MonoBehaviour {
    /// <summary>
    /// aaaaaaaaaaaaaaaaaaaaaaaaaaa
    /// </summary>
    private float Next_in_Time = 1f;       //次のシーンへ遷移するまでの時間
    private float StartFade_Time = 0.2f;    //フェードインが始まるまでの時間

    public void SceneLoad() {
        CameraFade.StartAlphaFade(Color.black, false, Next_in_Time, StartFade_Time, () => { SceneManager.LoadScene("Game"); });
    }
}
