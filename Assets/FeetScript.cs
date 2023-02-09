using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetScript : MonoBehaviour
{
    public PlayerScript playerScript;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 6) {
            playerScript.ResetJump();
        }
    }
}
