using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour {
    [SerializeField] FoodScript foodScript;
    [SerializeField] EnemyScript enemyScript;
    [SerializeField] int scoreToSpawnFood;
    [SerializeField] int scoreToSpawnEnemy;

    private float moveSpeed;
    private float speedLimit;
    private LogicManager logicManager;
    private float deadZone = -5;

    private void Start() {
        logicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        moveSpeed = logicManager.floorMoveSpeed;
        speedLimit = logicManager.speedLimit;

        if (logicManager.score > scoreToSpawnFood) {
            foodScript.SpawnFood(GetRandom());
        }

        if (logicManager.score > scoreToSpawnEnemy) {
            enemyScript.SpawnEnemy(GetRandom());
        }
    }


    void Update() {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone) {
            Destroy(gameObject);
        }
    }

    bool GetRandom(int max = 10) {
        int rand = Random.Range(0, max);

        return rand % 2 == 0 ? true : false;
    }
}
