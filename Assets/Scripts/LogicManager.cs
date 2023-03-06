using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogicManager : MonoBehaviour {
    private const string POINT = "Point";
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI pointText;
    public int score = 0;
    private int point = 0;

    private float timer = 0;
    private float timerLimit = 0.7f;

    public float floorMoveSpeed;
    public float speedLimit;

    [SerializeField] float spawnRateDecrease;
    [SerializeField] float floorSpeedIncAmount;
    [SerializeField] int scoreThresholdForSpdInc;

    public FloorSpawner floorSpawner;

    void Start() {
        point = PlayerPrefs.GetInt(POINT);
        pointText.text = point.ToString();
    }

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

    // Increasing speed after a certain score is achieved
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

    public int GetScore() {
        return score;
    }

    public int GetPoint() {
        return point;
    }

    public void PlayFoodSound() {
        GameManager.PlaySound(GameManager.Sound.Meat);
    }
}
