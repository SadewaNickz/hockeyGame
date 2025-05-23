using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonClickSound;
    public float delayBeforeScene = 0.3f; // Waktu tunggu sebelum pindah scene
    public GameObject ExitPopup;

    void Start()
    {
        ExitPopup.SetActive(false);
    }

    private void PlaySFX()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }

    public void StartGame()
    {
        StartCoroutine(DelayedSceneLoad("GameMenu"));
    }

    public void OpenCredits()
    {
        StartCoroutine(DelayedSceneLoad("CreditMenu"));
    }

    public void ExitGame()
    {
        ExitPopup.SetActive(true);
    }

    private IEnumerator DelayedSceneLoad(string sceneName)
    {
        PlaySFX();
        yield return new WaitForSeconds(delayBeforeScene);
        SceneManager.LoadScene(sceneName);
    }
}
