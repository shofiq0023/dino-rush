using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] PlayerScript playerScript;
    [SerializeField] string mainMenuName;
    [SerializeField] TextMeshProUGUI meatCount;
    [SerializeField] TextMeshProUGUI scoreCount;
    [SerializeField] TextMeshProUGUI highScore;
    [SerializeField] Animator transition;

    private void Awake() {
        Time.timeScale = 1;
        Application.targetFrameRate = 60;
    }

    public void PauseGame() {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame() {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void GameOver(int score, int point) {
        SaveInformation(score, point);
        
        int highestScore = PlayerPrefs.GetInt("highscore");

        gameOverScreen.SetActive(true);
        playerScript.ActiveDeath();

        meatCount.text = point.ToString();
        scoreCount.text = score.ToString();
        highScore.text = highestScore.ToString();

        Debug.Log("Score: " + score + ", Point: " + point + ", highscore: " + highestScore);

        Time.timeScale = 0;
    }

    public void RestartGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu() {
        StartCoroutine(LoadMainMenu(0));
    }

    public void SaveInformation(int score, int point) {
        if (score > PlayerPrefs.GetInt("highscore")) {
            PlayerPrefs.SetInt("highscore", score);
        }

        PlayerPrefs.SetInt("point", point);
    }

    IEnumerator LoadMainMenu(int index) {
        transition.SetTrigger("Start");

        yield return new WaitForSecondsRealtime(1);

        SceneManager.LoadScene(index);
    }
}
