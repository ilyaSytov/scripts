using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    [SerializeField] private Animator[] sceneAnimators;
    [SerializeField] private GameObject mask;
    private AudioSource audioSource;

    private void Awake() {
        StartCoroutine(LoadTimer());
        sceneAnimators = FindObjectsOfType<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void LoadNextLevel(string sceneName) {
        StartCoroutine(LoadWithAnimation(sceneName));
    }

    IEnumerator LoadWithAnimation(string sceneName) {
        audioSource.Play();
        mask.SetActive(true);
        foreach (Animator anim in sceneAnimators) {
            anim.SetTrigger("levelChange");
        }
        yield return new WaitForSeconds(1.15f);
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator LoadTimer() {
        mask.SetActive(true);
        yield return new WaitForSeconds(0.65f);
        mask.SetActive(false);
    }
}
