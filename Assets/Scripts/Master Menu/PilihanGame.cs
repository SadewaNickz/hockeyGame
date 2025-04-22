using UnityEngine;
using UnityEngine.SceneManagement; // Untuk pindah scene
using System.Collections;

public class PilihanGame : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonClickSound;
    public float delayBeforeScene = 0.3f; // Waktu tunggu sebelum pindah scene

    private void PlaySFX()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }

    // Fungsi tombol "Start"
    public void TebakGame()
    {
        // Ganti ke Scene Tebak Club Bola
        Destroy(GameObject.Find("BGMPlayer"));
        StartCoroutine(DelayedSceneLoad("main_menu"));
    }

    // Fungsi tombol "Credits"
    public void HockeyGame()
    {
        // Bisa buka scene Hockey Sepak Bola
        Destroy(GameObject.Find("BGMPlayer"));
        StartCoroutine(DelayedSceneLoad("Menu"));
    }

    public void ComingSoon()
    {
        // Game yang sedang digarap
        Destroy(GameObject.Find("BGMPlayer"));
        StartCoroutine(DelayedSceneLoad("Coming"));
    }

    // Fungsi tombol "Back"
    public void BackBotton()
    {
        StartCoroutine(DelayedSceneLoad("MainMenu")); // Kembali Ke Main Mwnu
    }

    private IEnumerator DelayedSceneLoad(string sceneName)
    {
        PlaySFX();
        yield return new WaitForSeconds(delayBeforeScene);
        SceneManager.LoadScene(sceneName);
    }

}
