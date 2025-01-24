using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int weaponDamage; // This will store the damage for the equipped weapon.
    private bool isInWolfTrigger; // Tracks if the player is in the wolf's collider
    private Animal targetWolf; // Tracks the wolf in the trigger
    
    // Reference to player's current weapon status (fists or axe)
    private bool isWeaponEquipped = false;

    private void Start()
    {
        // By default, the player starts with fists
        SetWeaponDamage(false);  // False = Fists, True = Weapon equipped
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            targetWolf = other.GetComponent<Animal>();
            if (targetWolf != null)
            {
                isInWolfTrigger = true;
                Debug.Log($"Player entered {targetWolf.animalName}'s trigger collider.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Animal") && targetWolf != null && other.gameObject == targetWolf.gameObject)
        {
            isInWolfTrigger = false;
            Debug.Log($"Player exited {targetWolf.animalName}'s trigger collider.");
            targetWolf = null;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click
        {
            if (isInWolfTrigger && targetWolf != null)
            {
                Debug.Log($"Attacking {targetWolf.animalName}!");
                targetWolf.TakeDamage(weaponDamage);
            }
            else
            {
                //Debug.Log("No target to attack.");
            }
        }
    }

    // Call this method when the player equips or unequips the weapon
    public void EquipWeapon(bool isEquipped)
    {
        isWeaponEquipped = isEquipped;
        SetWeaponDamage(isEquipped);
    }

    // Set the damage based on whether the player is using fists or a weapon
    private void SetWeaponDamage(bool isEquipped)
    {
        if (isEquipped)
        {
            weaponDamage = 20; // Axe damage
        }
        else
        {
            weaponDamage = 2; // Fists damage
        }
    }
}
