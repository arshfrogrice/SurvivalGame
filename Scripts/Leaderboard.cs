using UnityEngine;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    public TextMeshProUGUI survivalTimeText; // Text to display current survival time
    public TextMeshProUGUI bestTimeText;    // Text to display best survival time
    public GameObject leaderboardPanel;     // Leaderboard panel object

    private float survivalTime;             // Current survival time in seconds
    private float bestTime;                 // Best survival time across runs

    private void Start()
    {
        // Load the best time from PlayerPrefs or initialize to 0
        bestTime = PlayerPrefs.GetFloat("BestTime", 0f);

        UpdateLeaderboardUI();
    }

    private void Update()
    {
        // Increment survival time each frame
        survivalTime += Time.deltaTime;

        // Update the UI
        UpdateLeaderboardUI();
    }

    private void UpdateLeaderboardUI()
    {
        survivalTimeText.text = FormatTime(survivalTime);
        bestTimeText.text = FormatTime(bestTime);
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void EndGame()
    {
        // Check if this run's survival time is the best
        if (survivalTime > bestTime)
        {
            bestTime = survivalTime;
            PlayerPrefs.SetFloat("BestTime", bestTime); // Save the best time
        }

        // Save the survival time
        PlayerPrefs.SetFloat("SurvivalTime", survivalTime);

        // Save PlayerPrefs
        PlayerPrefs.Save();

        // Pause the game and display the leaderboard panel
        leaderboardPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void EndGames()
    {
        // Check if this run's survival time is the best
        if (survivalTime > bestTime)
        {
            bestTime = survivalTime;
            PlayerPrefs.SetFloat("BestTime", bestTime); // Save the best time
        }

        // Save the survival time
        PlayerPrefs.SetFloat("SurvivalTime", survivalTime);

        // Save PlayerPrefs
        PlayerPrefs.Save();

        // Pause the game and display the leaderboard panel
        leaderboardPanel.SetActive(false);
        Time.timeScale = 0;
    }
    public void UpdateSurvivalTime()
    {
    float survivalTime = Time.timeSinceLevelLoad; // Get the elapsed time since the level started
    Debug.Log("Survival Time Updated: " + survivalTime);

    // Store the survival time where it needs to go (e.g., to PlayerPrefs or a UI element)
    PlayerPrefs.SetFloat("SurvivalTime", survivalTime); // Optional for persistence
    // Or update any other variable that's being used
    }
    public void OnGameComplete()
    {
    UpdateSurvivalTime(); // Save survival time when the game ends successfully
    Debug.Log("Game Completed!");
    
    }
}
