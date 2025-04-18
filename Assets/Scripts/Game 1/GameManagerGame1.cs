using UnityEngine;
using UnityEngine.UI;

public class GameManagerGame1 : MonoBehaviour
{
    public int score = 100;
    public int lives = 6;
    public float totalGameTime = 600f;
    private float currentTime;

    public Image[] lifeImages;
    public GameObject[] levels;
    private int currentLevel = 0;

    public Text scoreText;
    public Text livesText;
    public Text timerText;
    public Text levelText;

    public GameObject endPanel;
    public Text finalScoreText;

    private bool isPaused = false;
    public GameObject PauseMenu;
    public GameObject Gameplay;

    void Start()
    {
        levels = new GameObject[10];
        currentTime = totalGameTime;
        UpdateUI();
        ActivateLevel(currentLevel);

        endPanel.SetActive(false);
        PauseMenu.SetActive(false);
        Gameplay.SetActive(true);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (!isPaused && currentTime > 0 && lives > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimer();
        }
        else if (currentTime <= 0 || lives <= 0)
        {
            GameOver();
        }
    }

    public void Answer(bool isCorrect)
    {
        if (!isCorrect)
        {
            lives--;
            score -= 10;

            if (lives >= 0 && lives < lifeImages.Length)
            {
                lifeImages[lives].enabled = false;
            }

            UpdateUI();

            if (lives <= 0)
            {
                GameOver();
                return;
            }
        }
        else
        {
            score += 100;
            UpdateUI();

            if (currentLevel + 1 >= levels.Length)
            {
                Win();
            }
            else
            {
                NextLevel();
            }
        }
    }

    public void NextLevel()
    {
        levels[currentLevel].SetActive(false);
        currentLevel++;

        if (currentLevel >= levels.Length)
        {
            Win();
            return;
        }

        levels[currentLevel].SetActive(true);
        UpdateUI();
    }

    void ActivateLevel(int index)
    {
        foreach (GameObject level in levels)
        {
            if (level != null)
                level.SetActive(false);
        }

        if (index < levels.Length && levels[index] != null)
        {
            levels[index].SetActive(true);
        }
    }

    void UpdateUI()
    {
        scoreText.text = score.ToString();
        livesText.text = lives.ToString();
        levelText.text = $"{currentLevel + 1}";
    }

    void UpdateTimer()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        ShowEndPanel();
    }

    void Win()
    {
        if (currentTime <= 300f)
        {
            score += 5000;
            Debug.Log("Bonus skor +5000 karena selesai < 5 menit!");
        }

        ShowEndPanel();
    }

    void ShowEndPanel()
    {
        Debug.Log("Permainan selesai!");
        finalScoreText.text = score.ToString();
        endPanel.SetActive(true);
        Gameplay.SetActive(false);
        Time.timeScale = 0;
    }

    public void pause_menu()
    {
        isPaused = !isPaused;
        PauseMenu.SetActive(isPaused);
        Gameplay.SetActive(!isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void ResumeGame()
    {
        isPaused = false;
        PauseMenu.SetActive(false);
        Gameplay.SetActive(true);
        Time.timeScale = 1f;
    }

    public void play_again()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
