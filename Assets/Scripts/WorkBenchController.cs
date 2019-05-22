using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// This script spawns a random piece into a spawnpoint, which lies atop the workbench.
/// A new piece should spawn after an old one has either fallen into the void or has become part of the tower.
/// </summary>
public class WorkBenchController : MonoBehaviour
{
    public GameObject spawnPoint;

    private List<GameObject> towerPieces = new List<GameObject>();

    void Start() {
        towerPieces = Resources.LoadAll<GameObject>("Objects").ToList();        // Load all potential building pieces into a list
    }

    void Update() {
        if (PlayerPrefs.GetInt("spawnPiece") == 1) {
            GameObject obj = towerPieces[Random.Range(0, towerPieces.Count)].gameObject;                    // Randomly select a piece
            Instantiate(obj, spawnPoint.transform.position, Quaternion.identity, spawnPoint.transform);     // Spawn the piece
            PlayerPrefs.SetInt("spawnPiece", 0);
        }
    }
}
