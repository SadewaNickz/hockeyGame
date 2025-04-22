using UnityEngine;
using UnityEngine.SceneManagement;

public class HalamanManager : MonoBehaviour
{
    public bool isEscapeToExit;

    void Start()
    {
        // Bisa panggil musik sesuai scene
        if (SceneManager.GetActiveScene().name == "Main")
        {
            if (AudioManager.instance != null)
                AudioManager.instance.PlayGameplayMusic();
        }
        else if (SceneManager.GetActiveScene().name == "Menu")
        {
            if (AudioManager.instance != null)
                AudioManager.instance.PlayGameOverMusic();
        }
        else if (SceneManager.GetActiveScene().name == "LawanBot")
        {
            if (AudioManager.instance != null)
                AudioManager.instance.PlayGameplayMusic();
        }
    }

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
                KembaliKeMenu();
            }
        }
    }

    public void MulaiPermainan()
    {
        SceneManager.LoadScene("Main");

    }

    public void KembaliKeMenu()
    {
        SceneManager.LoadScene("Menu");

    }

    public void MulaiLawanBot()
    {
    SceneManager.LoadScene("LawanBot");
    }

    public void ChooseCharacterBot()
    {
    SceneManager.LoadScene("ChooseChar");
    }
}
