using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetScript : MonoBehaviour
{
    public PlayerScript playerScript;

    // For checking if the player hit the ground or not
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 6) {
            playerScript.ResetJump();
        }
    }
}
