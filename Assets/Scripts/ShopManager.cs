using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour {
    private const string PLAYER_JUMP_COUNT = "PlayerJumpCount";
    private const string POINT = "Point";
    private const string MEAT_REQUIRED = "MeatRequired";
    private const int firstTimeMeatRequirement = 50;
    private const int meatRequirementIncrementCount = 10;
    
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private GameObject shopMenu;
    [SerializeField] private TextMeshProUGUI meatRequiredText;
    [SerializeField] private TextMeshProUGUI currentMeatText;
    [SerializeField] private TextMeshProUGUI totalMeatCountText;
    [SerializeField] private TextMeshProUGUI totalJumpCountText;

    private int meatRequired;
    private int currentMeat;
    private int currentJumpCount;

    private void Awake() {
        currentMeat = PlayerPrefs.GetInt(POINT);
        currentJumpCount = PlayerPrefs.GetInt(PLAYER_JUMP_COUNT);

        // Set the required meat count
        if (PlayerPrefs.GetInt(MEAT_REQUIRED) == 0) {
            PlayerPrefs.SetInt(MEAT_REQUIRED, firstTimeMeatRequirement);
        } else {
            meatRequired = PlayerPrefs.GetInt(MEAT_REQUIRED);
        }
    }

     // Shop menu button
    public void ShopButton() {
        audioSource.PlayOneShot(audioClip);
        shopMenu.SetActive(true);

        meatRequiredText.text = meatRequired.ToString();
        currentMeatText.text = PlayerPrefs.GetInt(POINT).ToString();
        if (!CanBuyJump()) {
            currentMeatText.color = Color.red;
        }
    }

    // Back button in Shop menu
    public void ShopButtonBack() {
        audioSource.PlayOneShot(audioClip);
        shopMenu.SetActive(false);
    }

    // Buy jump button in Shop menu
    public void BuyJump() {
        if (CanBuyJump()) {
            audioSource.PlayOneShot(audioClip);
            PlayerPrefs.SetInt(MEAT_REQUIRED, meatRequired + meatRequirementIncrementCount);
            PlayerPrefs.SetInt(PLAYER_JUMP_COUNT, currentJumpCount + 1);
            PlayerPrefs.SetInt(POINT, currentMeat - meatRequired);
            
            UpdateMeatCount();
        }
    }

    private bool CanBuyJump() {
        if (meatRequired <= currentMeat) {
            return true;
        } else {
            return false;
        }
    }

    private void UpdateMeatCount() {
        meatRequired = PlayerPrefs.GetInt(MEAT_REQUIRED);
        meatRequiredText.text = meatRequired.ToString();

        string currentMeat = PlayerPrefs.GetInt(POINT).ToString();
        currentMeatText.text = currentMeat;

        if (!CanBuyJump()) {
            currentMeatText.color = Color.red;
        }

        totalMeatCountText.text = currentMeat;
        totalJumpCountText.text = PlayerPrefs.GetInt(PLAYER_JUMP_COUNT).ToString();
    }
}
