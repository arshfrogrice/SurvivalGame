using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int id;
    public int value=1;
    public string itemName;       // Name of the item
    public Sprite icon;           // Icon to display in the inventory
    public bool isStackable;      // Can the item be stacked?
    public int maxStackSize = 64;  // Maximum stack size if stackable
    public Itemtype itemtype;
    public int damage;

    public enum Itemtype{
        Food,
        Tool,
        Book,
        Radio

    }
}
