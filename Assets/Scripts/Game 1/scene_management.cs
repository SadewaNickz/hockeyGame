using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_management : MonoBehaviour
{
    public bool isEscapeToExit;
    public GameObject PauseMenu;
    public GameObject Gameplay;
    public GameObject Level_1, Level_2, Level_3, Level_4, Level_5, Level_6, Level_7, Level_8, Level_9, Level_10;

    private bool isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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

    public void nextLevel()
    {
        Level_1.SetActive(false);
        Level_2.SetActive(true);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
