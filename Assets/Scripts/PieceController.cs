using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    private GameObject xReference;
    private GameObject yReference;
    private GameObject zReference;

    private float xBase;
    private float yBase;
    private float zBase;

    void Start() {
        xReference = GameObject.FindGameObjectWithTag("XSlider");
        yReference = GameObject.FindGameObjectWithTag("YSlider");
        zReference = GameObject.FindGameObjectWithTag("ZSlider");

        xBase = PlayerPrefs.GetFloat("pieceBaseX");
        yBase = PlayerPrefs.GetFloat("pieceBaseY");
        zBase = PlayerPrefs.GetFloat("pieceBaseZ");
    }

    void Update() {
        /*
         * TODO
         * get scaling working
        this.gameObject.transform.localScale = new Vector3(xBase, yBase, zBase); // TODO: add slider position
         * delete sliders upon pickup
         * when collision with towerpiece...
         * * calculate towerheight, set playerprefs float
         * * lower the tower so that objects can be placed on it again (via playerprefs)
         * * re-spawn sliders again (which will then spawn a new object
         * * destroy this script!
        */
    }
}
