using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script handles the core mechanic of the game.
/// Every piece must be able to be re-scaled, grabbed and put on the Tower.
/// Sliders are used for rescaling, they are referenced and therefore must be in the scene before the piece is spawned.
/// Grabbing causes the sliders to disappear.
/// Successfully putting the piece onto the Tower will give points and spawn a new piece.
/// </summary>
public class PieceController : MonoBehaviour
{
    private GameObject xReference, yReference, zReference, sliders;

    private float xBase, xSlidePos, yBase, ySlidePos, zBase, zSlidePos;

    void Start() {
        xReference = GameObject.FindGameObjectWithTag("XSlider");
        yReference = GameObject.FindGameObjectWithTag("YSlider");
        zReference = GameObject.FindGameObjectWithTag("ZSlider");
        sliders = GameObject.FindGameObjectWithTag("Sliders");

        xBase = PlayerPrefs.GetFloat("pieceBaseX");
        yBase = PlayerPrefs.GetFloat("pieceBaseY");
        zBase = PlayerPrefs.GetFloat("pieceBaseZ");
    }

    void Update() {
        xSlidePos = xReference.transform.position.x;
        ySlidePos = yReference.transform.position.x;
        zSlidePos = zReference.transform.position.x;

        this.gameObject.transform.localScale = new Vector3(xBase + xSlidePos, yBase + ySlidePos, zBase + zSlidePos);

        // TODO - fix this / find better solution. Sliders are immediately destroyed.
        if (transform.position.y > 0) Destroy(sliders);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "TowerPiece") {
            // is Tower higher? if so, calculate height difference and set enable "lowerTower"
            if (transform.position.y > PlayerPrefs.GetFloat("currentTowerHeight")) {
                PlayerPrefs.SetFloat("heightDifference", transform.position.y - PlayerPrefs.GetFloat("currentTowerHeight"));
                PlayerPrefs.SetInt("lowerTower", 1);
            }
            // spawn next object
            PlayerPrefs.SetInt("spawnSliders", 1);
            Destroy(this);
        }
        if (collision.gameObject.tag == "Doom") PlayerPrefs.SetInt("playerLives", PlayerPrefs.GetInt("playerLives") - 1);
    }
}
