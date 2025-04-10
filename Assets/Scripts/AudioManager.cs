using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audioSource;
    public AudioClip HowNow;   
    public AudioClip Farfare;  

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log("AudioManager aktif di scene: " + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayGameplayMusic()
    {
        Debug.Log("PlayGameplayMusic dipanggil");

        if (audioSource == null)
        {
            Debug.LogError("AudioSource belum diset!");
            return;
        }

        if (HowNow == null)
        {
            Debug.LogError("HowNow AudioClip belum diset!");
            return;
        }

        audioSource.clip = HowNow;
        audioSource.loop = true;
        audioSource.Play();

        Debug.Log("Now Playing: " + audioSource.clip.name);
    }

    public void PlayGameOverMusic()
    {
        Debug.Log("PlayGameOverMusic dipanggil");

        if (audioSource == null)
        {
            Debug.LogError("AudioSource belum diset!");
            return;
        }

        if (Farfare == null)
        {
            Debug.LogError("Farfare AudioClip belum diset!");
            return;
        }

        audioSource.clip = Farfare;
        audioSource.loop = true;
        audioSource.Play();

        Debug.Log("Now Playing: " + audioSource.clip.name);
    }
}
