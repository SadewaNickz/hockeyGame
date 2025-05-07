using UnityEngine;

public class PlaySoundOnHit : MonoBehaviour
{
    public AudioClip hitSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Optional: cek nama/tag lawan tabrakan
        if (collision.gameObject.name.Contains("Messi") || collision.gameObject.name.Contains("Ronaldo"))
        {
            audioSource.PlayOneShot(hitSound);
        }
    }
}
