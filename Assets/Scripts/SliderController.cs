using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    public GameObject sliders;

    void Update() {
        if (PlayerPrefs.GetInt("spawnSliders") == 1) {
            Instantiate(sliders);
            PlayerPrefs.SetInt("spawnPiece", 1);
            PlayerPrefs.SetInt("spawnSliders", 0);
        }
    }
}
