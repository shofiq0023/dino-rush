using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{

    [SerializeField]
    float moveSpeed;
    
    [SerializeField]
    float speedLimit;

    private float deadZone = -5;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone) {
            Destroy(gameObject);
        }
    }
}
