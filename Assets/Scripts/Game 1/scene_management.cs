using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_management : MonoBehaviour
{
    public bool isEscapeToExit;
    public GameObject Settings, MainMenu, Gameplay, PauseMenu;

    private bool isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Settings.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeToExit)
            {
                Application.Quit();
            }
            else
            {
                BackToMenu();
            }
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene("main_game");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("main_menu");
    }

    public void pause_menu()
    {
        isPaused = !isPaused;

        PauseMenu.SetActive(isPaused);
        Gameplay.SetActive(!isPaused);

        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void ResumeGame()
    {
        isPaused = false;
        PauseMenu.SetActive(false);
        Gameplay.SetActive(true);
        Time.timeScale = 1f;
    }

    public void OpenSettingsMenu()
    {
        MainMenu.SetActive(false);
        Settings.SetActive(true);
    }

    public void BackFromSettings()
    {
        Settings.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
