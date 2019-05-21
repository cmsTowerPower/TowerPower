using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    public string nextScene;

    void Awake() {
        resetPlayerPrefs();
        configTowerPieces();
        SceneManager.LoadScene(nextScene);
    }

    // Put PlayerPrefs that could destroy the game here
    // (in case that the game crashed and nothing was reset)
    void resetPlayerPrefs() {
        PlayerPrefs.SetInt("spawnSliders", 0);
        PlayerPrefs.SetInt("spawnPiece", 0);
        PlayerPrefs.SetInt("lowerTower", 0);
        PlayerPrefs.SetFloat("newTowerHeight", 0);
    }

    void configTowerPieces() {
        PlayerPrefs.SetFloat("pieceBaseX", 3);
        PlayerPrefs.SetFloat("pieceBaseY", 3);
        PlayerPrefs.SetFloat("pieceBaseZ", 3);
    }
}
