using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script updates the displayed Lives and Score.
/// </summary>
public class TextController : MonoBehaviour
{
    public GameObject liveText, scoreText;

    void Update() {
        if (PlayerPrefs.GetInt("playerLives") <= 0) {
            if (PlayerPrefs.GetInt("highscore") < PlayerPrefs.GetInt("playerScore")) PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("playerScore"));
            SceneManager.LoadScene(PlayerPrefs.GetString("gameOverSceneName"));
        }

        liveText.GetComponent<TextMesh>().text = "Lives: " + PlayerPrefs.GetInt("playerLives");
        scoreText.GetComponent<TextMesh>().text = "Score: " + PlayerPrefs.GetInt("playerScore");
    }
}
