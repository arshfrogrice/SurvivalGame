using UnityEngine;
using TMPro;  // Use TextMeshPro namespace

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
        // Update the UI text based on the current quest stage
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
                questDescription = "Collect leftovers and find a campfire before dawn.";  // Default objective
                break;
        }

        if (questText.text != questDescription) // Check if the text has changed
        {
            questText.text = questDescription;  // Update the text
            Debug.Log("Quest Text Updated: " + questText.text);  // Log to confirm text update
        }

        // Toggle the quest panel visibility
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleQuestPanel();
        }
    }

    // Toggle the visibility of the quest panel
    private void ToggleQuestPanel()
    {
        questText.transform.parent.gameObject.SetActive(!questText.transform.parent.gameObject.activeSelf);
    }
}
