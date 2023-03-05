using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectRationController : MonoBehaviour {
    public float targetAspectRatio;
    public Camera cameraRef;

    void Start() {
        float targetHeight = cameraRef.orthographicSize * 2f;
        float targetWidth = targetHeight * targetAspectRatio;
        float currentAspectRatio = (float)Screen.width / (float)Screen.height;

        if (currentAspectRatio > targetAspectRatio) {
            float differenceInSize = currentAspectRatio / targetAspectRatio;
            targetHeight /= differenceInSize;
        }
        cameraRef.orthographicSize = targetHeight / 2f;    
    }
}
