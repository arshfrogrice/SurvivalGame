using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryUI; // Reference to the inventory UI GameObject
    public GameObject bookPanel;
    public GameObject radioPanel;
    private bool isInventoryOpen = false; // To track the inventory's state
    public static InventoryManager Instance; // Singleton instance
    public List<Item> Items = new List<Item>();
    

    public Transform ItemContent;
    public GameObject InventoryItem;
    public MonoBehaviour playerMovementScript;

    private void Awake()
    {
        // Ensure Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destroy duplicate
        }
        else
        {
            Instance = this;
        }
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
        ListItems();  // Refresh the UI after removing the item
    }

    public void ListItems()
    {
        // Clear existing inventory UI items (if any)
        foreach (Transform child in ItemContent)
        {
            Destroy(child.gameObject);
        }

        // Instantiate new inventory UI items for each item in the inventory
        foreach (var item in Items)
        {
            Debug.Log($"Listing item: {item.itemName}, Icon: {item.icon}");

            GameObject obj = Instantiate(InventoryItem, ItemContent);

            // Locate the UI components in the prefab
            Text itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            Image itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            Button itemButton = obj.GetComponent<Button>(); // Assuming the item has a button

            if (itemName != null)
            {
                itemName.text = item.itemName;
                Debug.Log($"Assigned Name: {item.itemName}");
            }
            else
            {
                Debug.LogError("ItemName Text component not found.");
            }

            if (itemIcon != null)
            {
                itemIcon.sprite = item.icon;
                Debug.Log($"Assigned Icon: {item.icon}");
            }
            else
            {
                Debug.LogError("ItemIcon Image component not found.");
            }

            // Add the click listener to the button to handle the item click
            if (itemButton != null)
            {
                itemButton.onClick.AddListener(() => OnItemClick(item));
            }
        }
    }

    void OnItemClick(Item item)
    {
        if (item.itemtype == Item.Itemtype.Food)
        {
            // Handle food consumption
            if (PlayerStatsManager.Instance.currentHunger >= PlayerStatsManager.Instance.maxHunger)
            {
                Debug.Log("Hunger is already full! You can't eat more.");
                return; // Prevent consumption if hunger is full
            }

            PlayerStatsManager.Instance.IncreaseHunger(item.value);
            Remove(item);
        }
        else if (item.itemtype == Item.Itemtype.Tool)
        {
            // Handle tool equipping
            EquipSystem equipSystem = FindObjectOfType<EquipSystem>();
            if (equipSystem != null)
            {
                equipSystem.EquipTool(item); // Equip the tool
            }
            else
            {
                Debug.LogError("EquipSystem not found in the scene!");
            }
        }
        else if (item.itemtype == Item.Itemtype.Book)
        {
            // Handle book opening
            if (bookPanel != null)
            {
                bookPanel.SetActive(true); // Open the BookPanel
                Time.timeScale = 0f; // Pause the game
                Debug.Log("Book opened. Press Space to continue.");
            }
            else
            {
                Debug.LogError("BookPanel is not assigned in the Inspector!");
            }
        }
        else if (item.itemtype == Item.Itemtype.Radio)
        {
            // Handle book opening
            if (radioPanel != null)
            {
                radioPanel.SetActive(true); // Open the BookPanel
                Time.timeScale = 0f; // Pause the game
                Debug.Log("Radio opened.");
                
            }
            else
            {
                Debug.LogError("RadioPanel is not assigned in the Inspector!");
            }
        }
    }


    void Update()
    {
        // Check if the "B" key is pressed
        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleInventory();
        }
    }

    // Method to toggle the inventory's visibility
    public void ToggleInventory()
    {
        if (inventoryUI == null)
        {
            Debug.LogError("Inventory UI is not assigned in the Inspector!");
            return;
        }

        isInventoryOpen = !isInventoryOpen; // Toggle the state
        inventoryUI.SetActive(isInventoryOpen); // Activate or deactivate the inventory UI

        if (isInventoryOpen)
        {
            Cursor.lockState = CursorLockMode.None; // Unlock the cursor
            Cursor.visible = true;                // Show the cursor
            if (playerMovementScript != null) playerMovementScript.enabled = false; // Disable player movement
            ListItems();                          // Refresh the inventory UI when opened
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
            Cursor.visible = false;                  // Hide the cursor
            if (playerMovementScript != null) playerMovementScript.enabled = true; // Resume player movement
        }
    }

    // Method to close inventory via the cross button
    public void CloseInventory()
    {
        if (isInventoryOpen)
        {
            ToggleInventory(); // Call the ToggleInventory method to close the inventory and handle cursor unlock
        }
    }
}