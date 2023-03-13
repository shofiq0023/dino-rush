using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScriptForLevelBegin : MonoBehaviour {
    private float deadZone = -5;

    void Update() {
        if (transform.position.x < deadZone) {
            Destroy(gameObject);
        }
    }
}
