using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
    [SerializeField] string playSceneName;

    public void Play() {
        SceneManager.LoadScene(playSceneName);
    }

    public void Quit() {
        Application.Quit();
    }
}
