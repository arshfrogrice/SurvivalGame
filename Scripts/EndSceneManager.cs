using UnityEngine;
using TMPro;

public class EndSceneManager : MonoBehaviour
{
    public TextMeshProUGUI survivalTimeText; // Text for survival time
    public TextMeshProUGUI bestTimeText;    // Text for best time

    
    
    private void Start()
    {
        
        float bestTime = PlayerPrefs.GetFloat("BestTime", 0f);
        float survivalTime = PlayerPrefs.GetFloat("SurvivalTime", 0f);

        // Update the UI
        survivalTimeText.text =FormatTime(survivalTime);
        bestTimeText.text =FormatTime(bestTime);
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }


}
