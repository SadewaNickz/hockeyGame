using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public AudioClip goalSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bola"))
        {
            audioSource.PlayOneShot(goalSound);
        }
    }
}
