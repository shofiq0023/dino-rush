using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour {
    private const string PLAYER_JUMP_COUNT = "PlayerJumpCount";
    private const string POINT = "Point";
    private const string MEAT_REQUIRED = "MeatRequired";

    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime = 1;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private GameObject tutorialScreen;
    [SerializeField] private TextMeshProUGUI totalMeatCountText;
    [SerializeField] private TextMeshProUGUI totalJumpCountText;
    [SerializeField] private AudioSource audioSource;

    private int meatRequired;

    void Awake() {
        Time.timeScale = 1;
        Application.targetFrameRate = 60;
        GameObject soundGameObject = new GameObject("Sound");
        audioSource = soundGameObject.AddComponent<AudioSource>();
        
        // To show the jump count in main menu
        if (PlayerPrefs.GetInt(PLAYER_JUMP_COUNT) < 2) {
            PlayerPrefs.SetInt(PLAYER_JUMP_COUNT, 2);
        }

        // Set the required meat in shop menu and show the current jump and meat count in main menu
        totalMeatCountText.text = PlayerPrefs.GetInt(POINT).ToString();
        totalJumpCountText.text = PlayerPrefs.GetInt(PLAYER_JUMP_COUNT).ToString();
    }

    // Play button
    public void Play() {
        StartCoroutine(LoadLevel(1));
    }

    // Quit button
    public void Quit() {
        Application.Quit();
    }

    // Function to load level
    IEnumerator LoadLevel(int levelIndex) {
        audioSource.PlayOneShot(audioClip);
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void StartButton() {
        tutorialScreen.SetActive(true);
    }
}
