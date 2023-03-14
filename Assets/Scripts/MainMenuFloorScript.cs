using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuFloorScript : MonoBehaviour {
    private float deadZone = -5;
    
    void Update() {
        transform.position = transform.position + (Vector3.left) * Time.deltaTime;

        if (transform.position.x < deadZone) {
            Destroy(gameObject);
        }
    }
}
