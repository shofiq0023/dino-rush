using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogicManager : MonoBehaviour {
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI pointText;
    private int score = 0;
    private float timer = 0;
    private float timerLimit = 0.7f;
    private int point = 0;

    public float floorMoveSpeed;
    public float speedLimit;

    [SerializeField] float spawnRateDecrease;
    [SerializeField] float floorSpeedIncAmount;
    [SerializeField] int scoreThresholdForSpdInc;

    public FloorSpawner floorSpawner;

    void Start() {}

    void FixedUpdate() {
        if (timer < timerLimit) {
            timer += Time.deltaTime;
        } else {
            AddScore();
            timer = 0;
        }
    }

    void AddScore() {
        score += 1;
        scoreText.text = score.ToString();
        CheckScoreAndIncreaseSpeed();
    }

    void CheckScoreAndIncreaseSpeed() {
        if ((score % scoreThresholdForSpdInc) == 0) {
            floorMoveSpeed += floorSpeedIncAmount;
            floorSpawner.DecreaseSpawnRate(spawnRateDecrease);
        }

        if (floorMoveSpeed > speedLimit) {
            floorMoveSpeed = speedLimit;
        }
    }

    public void AddPoint(int n) {
        point += n;
        pointText.text = point.ToString();
    }
}
