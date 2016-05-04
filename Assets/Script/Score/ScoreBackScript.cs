using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreBackScript : MonoBehaviour {
    
    public void SceneLoad() {
        SceneManager.LoadScene("Menu");
    }
}
