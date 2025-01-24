using UnityEngine;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    public TextMeshProUGUI survivalTimeText; 
    public TextMeshProUGUI bestTimeText;    
    public GameObject leaderboardPanel;     

    private float survivalTime;             
    private float bestTime;                 

    private void Start()
    {
        
        bestTime = PlayerPrefs.GetFloat("BestTime", 0f);

        UpdateLeaderboardUI();
    }

    private void Update()
    {
        
        survivalTime += Time.deltaTime;

        
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
        
        if (survivalTime > bestTime)
        {
            bestTime = survivalTime;
            PlayerPrefs.SetFloat("BestTime", bestTime); 
        }

        
        PlayerPrefs.SetFloat("SurvivalTime", survivalTime);

        
        PlayerPrefs.Save();

        
        leaderboardPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void EndGames()
    {
        
        if (survivalTime > bestTime)
        {
            bestTime = survivalTime;
            PlayerPrefs.SetFloat("BestTime", bestTime); 
        }

        
        PlayerPrefs.SetFloat("SurvivalTime", survivalTime);

        
        PlayerPrefs.Save();

        
        leaderboardPanel.SetActive(false);
        Time.timeScale = 0;
    }
    public void UpdateSurvivalTime()
    {
    float survivalTime = Time.timeSinceLevelLoad; 
    Debug.Log("Survival Time Updated: " + survivalTime);

    
    PlayerPrefs.SetFloat("SurvivalTime", survivalTime); 
    
    }
    public void OnGameComplete()
    {
    UpdateSurvivalTime(); 
    Debug.Log("Game Completed!");
    
    }
}
