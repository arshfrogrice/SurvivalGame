using UnityEngine;

public class BookTrigger : MonoBehaviour
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
            if (questManager.currentQuestStage == QuestManager.QuestStage.FindBook)
            {
                questManager.UpdateQuestStage(QuestManager.QuestStage.ReadBook);
                Debug.Log("Quest updated to: Read the book.");
            }
        }
    }
}
