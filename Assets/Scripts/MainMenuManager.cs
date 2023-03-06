using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour {
    private const string PLAYER_JUMP_COUNT = "PlayerJumpCount";
    private const string POINT = "Point";
    private const string MEAT_REQUIRED = "MeatRequired";
    private const string FIRST_PLAY = "FirstPlay";

    [SerializeField] private string playSceneName;
    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime = 1;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private GameObject shopMenu;
    [SerializeField] private TextMeshProUGUI meatRequiredText;
    [SerializeField] private TextMeshProUGUI currentMeatText;

    private AudioSource audioSource;
    private int meatRequired;

    void Awake() {
        Time.timeScale = 1;
        Application.targetFrameRate = 60;
        GameObject soundGameObject = new GameObject("Sound");
        audioSource = soundGameObject.AddComponent<AudioSource>();
        
        if (PlayerPrefs.GetInt(PLAYER_JUMP_COUNT) < 2) {
            PlayerPrefs.SetInt(PLAYER_JUMP_COUNT, 2);
        }

        meatRequired = PlayerPrefs.GetInt(MEAT_REQUIRED, 50);
    }

    public void Play() {
        StartCoroutine(LoadLevel(1));
    }

    public void Quit() {
        Application.Quit();
    }

    IEnumerator LoadLevel(int levelIndex) {
        audioSource.PlayOneShot(audioClip);
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void ShopButton() {
        audioSource.PlayOneShot(audioClip);
        shopMenu.SetActive(true);

        meatRequiredText.text = meatRequired.ToString();
        currentMeatText.text = PlayerPrefs.GetInt(POINT).ToString();
        if (!CanBuyJump()) {
            currentMeatText.color = Color.red;
        }
    }

    public void ShopButtonBack() {
        audioSource.PlayOneShot(audioClip);
        shopMenu.SetActive(false);
    }

    public void BuyJump() {
        if (CanBuyJump()) {
            audioSource.PlayOneShot(audioClip);
            PlayerPrefs.SetInt(MEAT_REQUIRED, PlayerPrefs.GetInt(MEAT_REQUIRED + 10));
            PlayerPrefs.SetInt(PLAYER_JUMP_COUNT, PlayerPrefs.GetInt(PLAYER_JUMP_COUNT) + 1);
            
            UpdateMeatCount();
        }
    }

    private bool CanBuyJump() {
        int currentMeat = PlayerPrefs.GetInt(POINT);

        if (meatRequired <= currentMeat) {
            return true;
        } else {
            return false;
        }
    }

    private void UpdateMeatCount() {
        meatRequired = PlayerPrefs.GetInt(MEAT_REQUIRED);
        meatRequiredText.text = meatRequired.ToString();

        PlayerPrefs.SetInt(POINT, PlayerPrefs.GetInt(POINT) - meatRequired);
        string currentMeat = PlayerPrefs.GetInt(POINT).ToString();

        currentMeatText.text = currentMeat;
    }
}
