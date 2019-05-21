using UnityEngine;

public class TowerController : MonoBehaviour
{
    public int sinkRate = 30;

    private float sinkHeight;
    private int counter = 0;

    void Update() {
        if (PlayerPrefs.GetInt("lowerTower") == 1) {
            sinkHeight = PlayerPrefs.GetFloat("newTowerHeight");
            transform.position -= new Vector3(0, sinkHeight/sinkRate, 0);
            counter++;
            if (counter >= sinkRate) {
                PlayerPrefs.SetInt("lowerTower", 0);
                counter = 0;
            }
        }
    }
}
