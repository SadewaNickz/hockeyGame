using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BatasAkhirLiga : MonoBehaviour
{
    public static int nyawa = 3;

    public Image heart1;
    public Image heart2;
    public Image heart3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        nyawa--;

        UpdateUI();

        if (nyawa <= 0)
        {
            SceneManager.LoadScene("GameOver");
            nyawa = 3; // Reset nyawa
        }
    }

    void UpdateUI()
    {
        // Nonaktifkan hati satu per satu
        if (nyawa == 2)
            heart3.gameObject.SetActive(false);
        else if (nyawa == 1)
            heart2.gameObject.SetActive(false);
        else if (nyawa <= 0)
            heart1.gameObject.SetActive(false);
    }
}
