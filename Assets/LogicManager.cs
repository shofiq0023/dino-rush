using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogicManager : MonoBehaviour {
    public TextMeshProUGUI tmp;
    private int score = 0;
    private float timer = 0;
    private float timerLimit = 0.7f;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
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
        tmp.text = score.ToString();
    }
}
