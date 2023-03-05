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

    public SoundClips[] soundClipArray;

    private void Awake() {
        Time.timeScale = 1;
        Application.targetFrameRate = 60;
    }

    public enum Sound {
        Jump,
        Death,
        Button,
        Meat
    }

    // Array of Sound clips
    [System.Serializable]
    public class SoundClips {
        public Sound sound;
        public AudioClip audioClip;
    }

    public static void PlaySound(Sound sound) {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(GetAudioClip(sound));
    }

    private static AudioClip GetAudioClip(Sound sound) {
        GameManager thisManager = FindObjectOfType<GameManager>();

        foreach (SoundClips clip in thisManager.soundClipArray) {
            if (clip.sound == sound) {
                return clip.audioClip;
            }
        }

        return null;
    }

    // For game pause button
    public void PauseGame() {
        PlaySound(Sound.Button);
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    // For resume game button
    public void ResumeGame() {
        PlaySound(Sound.Button);
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    // For restart game button
    public void RestartGame() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    // For main menu button
    public void MainMenu() {
        StartCoroutine(LoadLevel(0));
    }

    // Function for game over screen
    public void GameOver(int score, int point) {
        PlaySound(Sound.Death);
        SaveInformation(score, point);
        
        int highestScore = PlayerPrefs.GetInt("highscore");

        gameOverScreen.SetActive(true);
        playerScript.ActiveDeath();

        meatCount.text = point.ToString();
        scoreCount.text = score.ToString();
        highScore.text = highestScore.ToString();

        Time.timeScale = 0;
    }

    // Saves player information like score and point
    public void SaveInformation(int score, int point) {
        if (score > PlayerPrefs.GetInt("highscore")) {
            PlayerPrefs.SetInt("highscore", score);
        }

        PlayerPrefs.SetInt("point", point);
    }

    // For loading level coroutine with delay
    IEnumerator LoadLevel(int index) {
        PlaySound(Sound.Button);
        transition.SetTrigger("Start");

        yield return new WaitForSecondsRealtime(1);

        SceneManager.LoadScene(index);
    }
}
