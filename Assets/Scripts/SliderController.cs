using UnityEngine;

/// <summary>
/// This script spawns sliders into the scene.
/// Sliders must be instantiated into the scene before a tower piece is spawned, because of references.
/// Sliders must also be destroyed if no longer needed (because they could get in the way when placing pieces).
/// </summary>
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
