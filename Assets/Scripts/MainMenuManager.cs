using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
    [SerializeField] string playSceneName;
    [SerializeField] Animator transition;
    [SerializeField] float transitionTime = 1;
    [SerializeField] AudioClip audioClip;

    private AudioSource audioSource;

    void Awake() {
        Time.timeScale = 1;
        Application.targetFrameRate = 60;
        GameObject soundGameObject = new GameObject("Sound");
        audioSource = soundGameObject.AddComponent<AudioSource>();
        
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
}
