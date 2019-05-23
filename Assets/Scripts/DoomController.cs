using UnityEngine;

/// <summary>
/// This script checks for falling TowerPieces and decreases the lives count if one collides
/// Also, a new object is spawned
/// </summary>
public class DoomController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "TowerPiece" || collision.gameObject.tag == "Tower") {
            PlayerPrefs.SetInt("playerLives", PlayerPrefs.GetInt("playerLives") - 1);
            Destroy(collision.gameObject);
        }
    }

}
