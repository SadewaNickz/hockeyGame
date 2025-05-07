using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void GoToGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
