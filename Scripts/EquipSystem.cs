using UnityEngine;

public class EquipSystem : MonoBehaviour
{
    public Transform toolHandler; // Assign the "ToolHandler" in the Inspector
    private GameObject equippedTool;
    public bool isAxeEquipped = false;
    public int equippedToolDamage = 5; // Default damage when no tool is equipped

    public void EquipTool(Item toolItem)
    {
        // Destroy any previously equipped tool
        if (equippedTool != null)
        {
            Destroy(equippedTool);
        }

        // Load the tool prefab from Resources or assign directly
        GameObject toolPrefab = Resources.Load<GameObject>($"Tools/{toolItem.itemName}");

        if (toolPrefab != null)
        {
            equippedTool = Instantiate(toolPrefab, toolHandler.position, toolHandler.rotation, toolHandler);
            Debug.Log($"{toolItem.itemName} equipped!");

            // Update equipped tool damage
            equippedToolDamage = toolItem.damage;
            isAxeEquipped = toolItem.itemName == "Axe";
        }
        else
        {
            Debug.LogError($"Tool prefab for {toolItem.itemName} not found in Resources/Tools!");
        }
    }
}
