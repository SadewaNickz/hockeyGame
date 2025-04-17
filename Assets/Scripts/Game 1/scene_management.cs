using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_management : MonoBehaviour
{
    public bool isEscapeToExit;
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
        SceneManager.LoadScene("gameplay");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("main_menu");
    }
    public void QuitApplication()
    {
        Application.Quit();
    }
}
