using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxScript : MonoBehaviour {
    [SerializeField] GameManager gameManager;
    [SerializeField] LogicManager logicManager;

    // Collision box on player which checks if the player hit the enemy
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 7) {
            gameManager.GameOver(logicManager.GetScore(), logicManager.GetPoint());
        }
    }
}
