using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour{
    private GameManager gameManager;

    private void Start() {
        gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 3) {
            gameManager.GameOver();
        }
    }

    public void SpawnEnemy(bool flag) {
        if (flag == true) {
            gameObject.SetActive(flag);
        } else {
            gameObject.SetActive(flag);
        }
    }
}
