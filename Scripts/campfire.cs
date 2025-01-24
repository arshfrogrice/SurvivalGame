using UnityEngine;

public class Campfire : MonoBehaviour
{
    public float temperatureIncreaseRate = 0.1f; // How fast the temperature increases when near the fire
    private TemperatureManager temperatureManager; // Reference to the TemperatureManager script

    void Start()
    {
        // Find the TemperatureManager script in the scene
        temperatureManager = FindObjectOfType<TemperatureManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        // If the player enters the campfire's radius
        if (other.CompareTag("Player") && temperatureManager != null)
        {
            temperatureManager.isNearHeatSource = true;
            Debug.Log("Player entered heat source range");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // If the player leaves the campfire's radius
        if (other.CompareTag("Player") && temperatureManager != null)
        {
            temperatureManager.isNearHeatSource = false;
            Debug.Log("Player exited heat source range");
        }
    }
}
