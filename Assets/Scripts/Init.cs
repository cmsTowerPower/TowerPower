using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    public string nextScene;

    void Awake() {
        resetPlayerPrefs();
        SceneManager.LoadScene(nextScene);
    }

    // Put PlayerPrefs that could destroy the game here
    // (in case that the game crashed and nothing was reset)
    void resetPlayerPrefs() {
        PlayerPrefs.SetInt("readyToSpawn", 0);
        PlayerPrefs.SetInt("readyToSink", 0);
        PlayerPrefs.SetFloat("newObjectHeight", 0);
    }
}