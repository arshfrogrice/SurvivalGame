using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float pickupRange = 2f; // Maximum range for picking up items
    public LayerMask itemLayer; // Layer for items to be picked up
    private Camera playerCamera;

    void Start()
    {
        playerCamera = Camera.main; // Get the main camera
    }

    //void Update()
    //{
        //if (Input.GetKeyDown(KeyCode.E))
        //{
            //TryPickupItem();
        //}
    //}

    //void TryPickupItem()
    //{
        // Find the closest item within the pickup range
        //Collider[] hitColliders = Physics.OverlapSphere(transform.position, pickupRange, itemLayer);
        
        //if (hitColliders.Length > 0)
        //{
            // Assuming only one item in range and it's the closest one
            //ItemPickup itemPickup = hitColliders[0].GetComponent<ItemPickup>();
            //if (itemPickup != null)
            //{
                //itemPickup.Pickup();
                //Debug.Log("Picked up: " + itemPickup.Item.name);
            //}
        //}
    //}
}
