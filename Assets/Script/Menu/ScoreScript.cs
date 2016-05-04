using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour {

    public void SceneLoad() {
        SceneManager.LoadScene("Score");
    }
}
