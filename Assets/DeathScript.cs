using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour {
    [SerializeField] GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 3) {
            gameManager.GameOver();
        }
    }
}
