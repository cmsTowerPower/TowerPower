using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorkBenchController : MonoBehaviour
{
    public GameObject spawnPoint;

    private List<GameObject> objects = new List<GameObject>();

    void Start() {
        objects = Resources.LoadAll<GameObject>("Objects").ToList();
    }

    void Update() {
        if (PlayerPrefs.GetInt("spawnPiece") == 1) {
            GameObject obj = objects[Random.Range(0, objects.Count)].gameObject;
            Instantiate(obj, spawnPoint.transform.position, Quaternion.identity, spawnPoint.transform);
            PlayerPrefs.SetInt("spawnPiece", 0);
        }
    }
}
