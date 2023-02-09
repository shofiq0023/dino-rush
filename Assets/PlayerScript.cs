using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public Rigidbody2D rb;
    public float jumpPower = 10;
    public int jumpLimit;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform feet;

    private int jumpCount = 0;

    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {
        if ((jumpCount < jumpLimit) && Input.GetKeyDown(KeyCode.Space)) {
            jump();
        }
    }

    void jump() {
        rb.velocity = Vector2.up * jumpPower;
        jumpCount++;
    }

    public void ResetJump() {
        jumpCount = 0;
    }
}
