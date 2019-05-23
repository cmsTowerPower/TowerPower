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

    private float xBase, xSliderBonus, yBase, ySliderBonus, zBase, zSliderBonus;

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
        // 0.3947823 is the default value, so the reference value needs to be reduced by that value
        // sliders also work reversed, so the difference needs to be made negative
        // since the outcoming value is 0.2 at max, it's amplified by 100 to actually make an impact
        xSliderBonus = -(xReference.transform.position.x - 0.3947823f) * 100;
        ySliderBonus = -(yReference.transform.position.x - 0.3947823f) * 100;
        zSliderBonus = -(zReference.transform.position.x - 0.3947823f) * 100;

        this.gameObject.transform.localScale = new Vector3(xBase + xSliderBonus, yBase + ySliderBonus, zBase + zSliderBonus);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Tower") {
            // is Tower higher? if so, give points, calculate height difference and enable "lowerTower"
            if (transform.position.y > PlayerPrefs.GetFloat("currentTowerHeight")) {
                PlayerPrefs.SetInt("points", PlayerPrefs.GetInt("points") + 10);
                PlayerPrefs.SetFloat("heightDifference", transform.position.y - PlayerPrefs.GetFloat("currentTowerHeight"));
                PlayerPrefs.SetInt("lowerTower", 1);
            }
            PlayerPrefs.SetInt("playerScore", PlayerPrefs.GetInt("playerScore") + PlayerPrefs.GetInt("points"));
            this.gameObject.tag = "Tower";
            prepareNext();
        }
        if (collision.gameObject.tag == "Doom") {
            PlayerPrefs.SetInt("playerLives", PlayerPrefs.GetInt("playerLives") - 1);
            prepareNext();
        }
    }

    void prepareNext() {
        Destroy(sliders);
        PlayerPrefs.SetInt("spawnSliders", 1);
        Destroy(this);
    }
}
