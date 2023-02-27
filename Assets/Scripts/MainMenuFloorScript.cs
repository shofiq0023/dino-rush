using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuFloorScript : MonoBehaviour {
    void Update() {
        transform.position = transform.position + (Vector3.left) * Time.deltaTime;

        if (transform.position.x < -2.9f) {
            Destroy(gameObject);
        }
    }
}
