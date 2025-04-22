using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private static BGMManager instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Hapus duplikat
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

