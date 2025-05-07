using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM3 : MonoBehaviour
{
    private static BGM3 instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Hapus duplikat
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Jika masuk ke scene LawanBot atau Main, hancurkan BGM2
        if (scene.name == "LawanBot" || scene.name == "Main" || scene.name == "MainMenu" || scene.name == "GameOver")
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe dari event untuk menghindari memory leak
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
