using UnityEngine;

public class SnowstormTrigger : MonoBehaviour
{
    public int damage = 10; // Damage to apply every 10 frames
    private bool isPlayerInside = false;
    private PlayerStatsManager playerStats; // Reference to the player's stats manager
    private int frameCounter = 0; // Counter to track frames

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered snowstorm boundary!");
            isPlayerInside = true;

            // Get the PlayerStatsManager reference
            playerStats = other.GetComponent<PlayerStatsManager>();
            if (playerStats == null)
            {
                Debug.LogError("PlayerStatsManager script not found on the player!");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited snowstorm boundary!");
            isPlayerInside = false;
        }
    }

    private void Update()
    {
        if (isPlayerInside && playerStats != null)
        {
            frameCounter++; // Increment the frame counter

            // Apply damage every 10 frames
            if (frameCounter >= 10)
            {
                playerStats.TakeDamage(damage);
                frameCounter = 0; // Reset the counter
            }
        }
    }
}
