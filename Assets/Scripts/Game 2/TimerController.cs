using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public float startTime = 60f; // waktu mulai (dalam detik)
    private float currentTime;
    public Text timerText; // assign dari Inspector
    public BallController ballController; // drag BallController di Inspector

    void Start()
    {
        currentTime = startTime;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            currentTime = 0;
            UpdateTimerDisplay();
            TimerEnded();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TimerEnded()
    {
        Debug.Log("Waktu Habis!");
        
        if (ballController != null)
        {
            ballController.CekPemenangSaatWaktuHabis();
        }
    }
}
