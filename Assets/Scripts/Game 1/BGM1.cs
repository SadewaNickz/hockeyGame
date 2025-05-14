using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM1 : MonoBehaviour
{
    private static BGM1 instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Jika masuk ke scene LawanBot atau Main, hancurkan BGM2
        if (scene.name == "LawanBot" || scene.name == "Main" || scene.name == "MainMenu" || scene.name == "main_game")
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
