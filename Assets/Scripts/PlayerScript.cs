using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerScript : MonoBehaviour {
    private const string PLAYER_JUMP_COUNT = "PlayerJumpCount";

    public Rigidbody2D rb;
    public float jumpPower = 10;
    private int jumpLimit;
    private bool isDead = false;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform feet;
    [SerializeField] GameManager gameManager;

    private int jumpCount = 0;


    private void Awake() {
        jumpLimit = PlayerPrefs.GetInt(PLAYER_JUMP_COUNT);
    }

    private void Update() {
        if ((jumpCount < jumpLimit) && 
            ((Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began))) && 
            Time.timeScale > 0 && 
            !isDead) {
                // if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId)) {
                //     return;
                // }
                Jump();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            gameManager.PauseGame();
        }
    }

    private void Jump() {
        rb.velocity = Vector2.up * jumpPower;
        jumpCount++;
        GameManager.PlaySound(GameManager.Sound.Jump);
    }

    public void ResetJump() {
        jumpCount = 0;
    }

    public void ActiveDeath() {
        isDead = true;
    }
}
