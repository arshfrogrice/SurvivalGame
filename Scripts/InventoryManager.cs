using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryUI; // Reference to the inventory UI GameObject
    public GameObject bookPanel;
    public GameObject radioPanel;
    private bool isInventoryOpen = false; 
    public static InventoryManager Instance; 
    public List<Item> Items = new List<Item>();
    

    public Transform ItemContent;
    public GameObject InventoryItem;
    public MonoBehaviour playerMovementScript;

    private void Awake()
    {
       
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
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
        ListItems();  
    }

    public void ListItems()
    {
        
        foreach (Transform child in ItemContent)
        {
            Destroy(child.gameObject);
        }

        
        foreach (var item in Items)
        {
            Debug.Log($"Listing item: {item.itemName}, Icon: {item.icon}");

            GameObject obj = Instantiate(InventoryItem, ItemContent);

            
            Text itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            Image itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            Button itemButton = obj.GetComponent<Button>(); 

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
                return; 
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
                equipSystem.EquipTool(item); 
            }
            else
            {
                Debug.LogError("EquipSystem not found in the scene!");
            }
        }
        else if (item.itemtype == Item.Itemtype.Book)
        {
            
            if (bookPanel != null)
            {
                bookPanel.SetActive(true); 
                Time.timeScale = 0f; 
                Debug.Log("Book opened. Press Space to continue.");
            }
            else
            {
                Debug.LogError("BookPanel is not assigned in the Inspector!");
            }
        }
        else if (item.itemtype == Item.Itemtype.Radio)
        {
            
            if (radioPanel != null)
            {
                radioPanel.SetActive(true); 
                Time.timeScale = 0f; 
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
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleInventory();
        }
    }

    
    public void ToggleInventory()
    {
        if (inventoryUI == null)
        {
            Debug.LogError("Inventory UI is not assigned in the Inspector!");
            return;
        }

        isInventoryOpen = !isInventoryOpen; 
        inventoryUI.SetActive(isInventoryOpen); 

        if (isInventoryOpen)
        {
            Cursor.lockState = CursorLockMode.None; 
            Cursor.visible = true;                
            if (playerMovementScript != null) playerMovementScript.enabled = false; 
            ListItems();                          
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked; 
            Cursor.visible = false;                  
            if (playerMovementScript != null) playerMovementScript.enabled = true; 
        }
    }

    
    public void CloseInventory()
    {
        if (isInventoryOpen)
        {
            ToggleInventory(); 
        }
    }
}