using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    private QuestManager questManager;

    private void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the current stage is FindBook
            if (questManager.currentQuestStage == QuestManager.QuestStage.ReadBook)
            {
                questManager.UpdateQuestStage(QuestManager.QuestStage.FindLostItem);
                Debug.Log("Quest updated to: Read the book.");
            }
        }
    }
}
