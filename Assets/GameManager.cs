using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] PlayerScript playerScript;
    [SerializeField] string mainMenuName;

    private void Awake() {
        Time.timeScale = 1;    
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
        gameOverScreen.SetActive(true);
        playerScript.ActiveDeath();
        SaveInformation(score, point);
        Debug.Log("Score: " + score + ", Point: " + point);

        Time.timeScale = 0;
    }

    public void RestartGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu() {
        SceneManager.LoadScene(mainMenuName);
    }

    public void SaveInformation(int score, int point) {
        PlayerPrefs.SetInt("highscore", score);
        PlayerPrefs.SetInt("point", point);
    }
}
