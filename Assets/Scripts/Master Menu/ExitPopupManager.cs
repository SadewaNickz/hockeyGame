using UnityEngine;

public class ExitPopupManager : MonoBehaviour
{
    public GameObject exitPopup;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Tampilkan popup kalau belum ditampilkan
            if (!exitPopup.activeSelf)
            {
                exitPopup.SetActive(true);
                Time.timeScale = 0f; // Opsional: freeze game
            }
            else
            {
                ClosePopup();
            }
        }
    }

    public void ConfirmExit()
    {
        Time.timeScale = 1f; // Pastikan normal dulu
        Application.Quit();
        Debug.Log("Keluar dari game");
    }

    public void ClosePopup()
    {
        exitPopup.SetActive(false);
        Time.timeScale = 1f;
    }
}
