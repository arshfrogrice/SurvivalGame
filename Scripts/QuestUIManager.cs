using UnityEngine;
using TMPro;  

public class QuestUIManager : MonoBehaviour
{
    public TextMeshProUGUI questText;
    private QuestManager questManager;

    private void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
    }

    private void Update()
    {
        
        string questDescription = "";
        switch (questManager.currentQuestStage)
        {
            case QuestManager.QuestStage.FindCampfire:
                questDescription = "Collect leftovers and find a campfire before dawn.";
                break;
            case QuestManager.QuestStage.FindMansion:
                questDescription = "Find the big mansion.";
                break;
            case QuestManager.QuestStage.FindBook:
                questDescription = "Find the book in the mansion.";
                break;
            case QuestManager.QuestStage.ReadBook:
                questDescription = "Read the Content of the Book";
                break;
            case QuestManager.QuestStage.FindLostItem:
                questDescription = "Find the lost item from the bear cave.";
                break;
            default:
                questDescription = "Collect leftovers and find a campfire before dawn.";  
                break;
        }

        if (questText.text != questDescription) 
        {
            questText.text = questDescription;  
            Debug.Log("Quest Text Updated: " + questText.text);  
        }

        
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleQuestPanel();
        }
    }

    
    private void ToggleQuestPanel()
    {
        questText.transform.parent.gameObject.SetActive(!questText.transform.parent.gameObject.activeSelf);
    }
}
