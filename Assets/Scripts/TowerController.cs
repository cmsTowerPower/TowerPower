using UnityEngine;

/// <summary>
/// This script causes the tower platform to lower, so that new pieces can be put on it easier.
/// </summary>
public class TowerController : MonoBehaviour
{
    public int sinkRate = 30;

    private float sinkHeight;
    private int counter = 0;

    void Start() {
        PlayerPrefs.SetFloat("currentTowerHeight", transform.position.y);
    }

    void Update() {
        if (PlayerPrefs.GetInt("lowerTower") == 1) {
            sinkHeight = PlayerPrefs.GetFloat("heightDifference");
            transform.position -= new Vector3(0, sinkHeight/sinkRate, 0);
            counter++;
            if (counter >= sinkRate) {
                PlayerPrefs.SetInt("lowerTower", 0);
                counter = 0;
            }
        }
    }
}
