using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxScript : MonoBehaviour {
    [SerializeField] GameManager gameManager;
    [SerializeField] LogicManager logicManager;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 7) {
            gameManager.GameOver(logicManager.GetScore(), logicManager.GetPoint());
        }
    }
}
