using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public GameObject scoreText, highscoreText;

    void Start() {
        scoreText.GetComponent<TextMesh>().text = "Your score: " + PlayerPrefs.GetInt("playerScore");
        highscoreText.GetComponent<TextMesh>().text = "Highscore: " + PlayerPrefs.GetInt("highscore");
    }

    public void restartGame() => SceneManager.LoadScene("Init");
}
