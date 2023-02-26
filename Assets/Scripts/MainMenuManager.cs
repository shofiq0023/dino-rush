using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
    [SerializeField] string playSceneName;
    [SerializeField] Animator transition;
    [SerializeField] float transitionTime = 1;

    void Awake() {
        Time.timeScale = 1;
    }

    public void Play() {
        StartCoroutine(LoadLevel(1));
    }

    public void Quit() {
        Application.Quit();
    }

    IEnumerator LoadLevel(int levelIndex) {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
