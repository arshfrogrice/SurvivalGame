using UnityEngine;

public class MansionTrigger : MonoBehaviour
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
            // Check if the current stage is FindMansion
            if (questManager.currentQuestStage == QuestManager.QuestStage.FindMansion)
            {
                questManager.UpdateQuestStage(QuestManager.QuestStage.FindBook);
                Debug.Log("Quest updated to: Find the book in the mansion!");
            }
        }
    }
}
