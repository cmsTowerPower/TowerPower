using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoController : MonoBehaviour {
    void Awake() {
        PlayerPrefs.SetInt("readyToSpawn", 1);
    }
}
