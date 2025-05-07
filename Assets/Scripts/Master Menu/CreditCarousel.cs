using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreditCarousel : MonoBehaviour
{
    public Image playerImage;
    public Sprite[] playerSprites;

    public Text creditText;
    [TextArea(3, 10)]
    public string[] creditContents;

    public float delayBeforeSwitch = 0.3f; // Delay agar SFX bisa terdengar dulu

    public AudioSource audioSource; // Tambahkan AudioSource
    public AudioClip buttonSFX;     // Tambahkan AudioClip untuk SFX tombol

    private int currentIndex = 0;
    private bool isSwitching = false;

    void Start()
    {
        UpdateDisplay();
    }

    public void Next()
    {
        if (!isSwitching)
        {
            PlayButtonSFX();
            StartCoroutine(DelayedSwitch(1));
        }
    }

    public void Previous()
    {
        if (!isSwitching)
        {
            PlayButtonSFX();
            StartCoroutine(DelayedSwitch(-1));
        }
    }

    IEnumerator DelayedSwitch(int direction)
    {
        isSwitching = true;
        yield return new WaitForSeconds(delayBeforeSwitch);

        currentIndex = (currentIndex + direction + playerSprites.Length) % playerSprites.Length;
        UpdateDisplay();

        isSwitching = false;
    }

    void UpdateDisplay()
    {
        if (playerSprites.Length > 0 && playerImage != null)
            playerImage.sprite = playerSprites[currentIndex];

        if (creditContents.Length > 0 && creditText != null)
            creditText.text = creditContents[currentIndex];
    }

    void PlayButtonSFX()
    {
        if (audioSource != null && buttonSFX != null)
            audioSource.PlayOneShot(buttonSFX);
    }
}
