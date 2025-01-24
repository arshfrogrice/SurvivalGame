using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item Item;  // Reference to the item
    private bool isPlayerInRange = false;  // Whether the player is inside the trigger zone

    // This method gets called when another collider enters the trigger
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered the trigger is the player
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;  // Set the flag to true
        }
    }

    // This method gets called when another collider exits the trigger
    private void OnTriggerExit(Collider other)
    {
        // Check if the collider that exited the trigger is the player
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;  // Set the flag to false
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // If the player is in range and presses E, pick up the item
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Add the item to the inventory
            InventoryManager.Instance.Add(Item);
            Destroy(gameObject); // Destroy the item after it's picked up
        }
    }
}

