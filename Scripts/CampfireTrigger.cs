using UnityEngine;

public class CampfireTrigger : MonoBehaviour
{
    private QuestManager questManager;

    private void Start()
    {
        // Find the QuestManager in the scene
        questManager = FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Update the quest stage to FindMansion if the current stage is FindCampfire
            if (questManager.currentQuestStage == QuestManager.QuestStage.FindCampfire)
            {
                questManager.UpdateQuestStage(QuestManager.QuestStage.FindMansion);
                Debug.Log("Quest updated: Find the big mansion!");
            }
        }
    }
}
