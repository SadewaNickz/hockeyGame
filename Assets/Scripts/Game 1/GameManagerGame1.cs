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
        // Inisialisasi array levels
        levels = new GameObject[10];

        // Isi array dengan GameObject bernama "Level_1" sampai "Level_10"
        for (int i = 0; i < 10; i++)
        {
            levels[i] = GameObject.Find("Level_" + (i + 1));

            if (levels[i] != null)
                levels[i].SetActive(false); // Matikan semua level dulu
            else
                Debug.LogWarning("Level_" + (i + 1) + " tidak ditemukan di Hierarchy!");
        }

        currentLevel = 0;

        // Aktifkan hanya Level_1
        if (levels[currentLevel] != null)
            levels[currentLevel].SetActive(true);

        currentTime = totalGameTime;
        UpdateUI();

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
        Debug.Log("Ditekan. isCorrect = " + isCorrect);

        if (!isCorrect)
        {
            Debug.Log("Jawaban SALAH");
            lives--;
            score -= 100;

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
            Debug.Log("Jawaban BENAR");
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
        ShowEndPanel(); // Bonus skor 5000 dihapus
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
