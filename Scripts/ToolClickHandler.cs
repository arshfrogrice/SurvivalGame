using UnityEngine;

public class ToolClickHandler : MonoBehaviour
{
    public Item toolItem; // Assign the corresponding Item asset in the Inspector

    private void OnMouseDown()
    {
        InventoryManager inventory = InventoryManager.Instance;

        if (inventory != null)
        {
            inventory.Add(toolItem); // Add the tool to the inventory
            Destroy(gameObject);    // Remove the tool from the world
        }
        else
        {
            Debug.LogError("InventoryManager instance not found!");
        }
    }
}
