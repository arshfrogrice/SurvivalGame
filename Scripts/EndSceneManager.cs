using UnityEngine;
using TMPro;

public class EndSceneManager : MonoBehaviour
{
    public TextMeshProUGUI survivalTimeText; 
    public TextMeshProUGUI bestTimeText;    

    
    
    private void Start()
    {
        
        float bestTime = PlayerPrefs.GetFloat("BestTime", 0f);
        float survivalTime = PlayerPrefs.GetFloat("SurvivalTime", 0f);

        
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
