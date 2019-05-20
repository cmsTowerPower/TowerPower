using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCheck : MonoBehaviour {
    private void OnCollisionEnter(Collision collision) {
        Debug.Log("COLLISION");
        Debug.Log("At: " + this.gameObject.name);
        Debug.Log("Object: " + collision.gameObject.name);
        Debug.Log("Parent: " + collision.gameObject.transform.parent.gameObject.name);
        Debug.Log("_____________________");
    }
}
