using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour {
    [SerializeField] FoodScript foodScript;
    [SerializeField] EnemyScript enemyScript;
    [SerializeField] int scoreToSpawnFood;
    [SerializeField] int scoreToSpawnEnemy;

    private float moveSpeed;
    private float deadZone = -5;
    private float speedLimit;
    private LogicManager logicManager;

    // Start is called before the first frame update
    void Start() {
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

    // Update is called once per frame
    void FixedUpdate() {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone) {
            Destroy(gameObject);
        }
    }

    bool GetRandom() {
        int rand = Random.Range(0, 10);

        return rand % 2 == 0 ? true : false;
    }
}
