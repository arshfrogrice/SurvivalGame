using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public enum QuestStage { None, FindCampfire, FindMansion, FindBook, ReadBook, FindLostItem }
    public QuestStage currentQuestStage = QuestStage.FindCampfire;

    // Display current objective text (can be shown on UI or in debug)
    public void UpdateQuestStage(QuestStage newStage)
    {
        currentQuestStage = newStage;
        DisplayCurrentObjective();
    }

    // Display the current objective based on the quest stage
    private void DisplayCurrentObjective()
    {
        switch (currentQuestStage)
        {
            case QuestStage.FindCampfire:
                Debug.Log("Objective: Collect leftovers and find a campfire before dawn.");
                break;
            case QuestStage.FindMansion:
                Debug.Log("Objective: Find the big mansion.");
                break;
            case QuestStage.FindBook:
                Debug.Log("Objective: Find the book in the mansion.");
                break;
            case QuestStage.ReadBook:
                Debug.Log("Objective: Read Book.");
                //questDescription = "Read the Content of the Book";
                break;
            case QuestStage.FindLostItem:
                Debug.Log("Objective: Find the lost item from the bear cave.");
                break;
            default:
                Debug.Log("Objective: Collect leftovers and find a campfire before dawn.");
                break; // Default quest objective
        }
    }

    private void Start()
    {
        // Set the default quest objective at the start
        DisplayCurrentObjective();
    }
}
