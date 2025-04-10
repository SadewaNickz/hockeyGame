using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PanelSelesai;

    void Start()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayGameplayMusic();
        }
    }

    public void GameSelesai()
    {
        PanelSelesai.SetActive(true);

        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayGameOverMusic();
        }
    }
}
