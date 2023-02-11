using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour {
    private LogicManager logicManager;

    void Start() {
        logicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();    
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 3) {
            logicManager.AddPoint(1);
            Destroy(gameObject);
        }
    }
}
