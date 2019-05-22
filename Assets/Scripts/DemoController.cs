using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script gives some additional control over the scene.
/// </summary>
public class DemoController : MonoBehaviour {
    void Awake() {
        PlayerPrefs.SetInt("spawnSliders", 1);      // spawn first object
    }
}
