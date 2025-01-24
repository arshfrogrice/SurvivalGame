using UnityEngine;
using UnityEngine.UI;

public class TemperatureManager : MonoBehaviour
{
    public float currentTemperature = 20f; // Starting temperature
    public float minTemperature = -10f; // Minimum temperature
    public float maxTemperature = 40f; // Maximum temperature
    public float temperatureDecreaseRate = 0.1f; // How fast temperature decreases
    public float heatIncreaseRate = 5f; // How fast temperature increases near heat source

    public Slider temperatureSlider; // Reference to the UI slider
    private PlayerStatsManager playerStatsManager; // Reference to PlayerStatsManager
    private TimeController timeController; // Reference to TimeController

    public bool isNearHeatSource = false; // Check if the player is near a heat source

    void Start()
    {
        // Initialize temperature and slider
        if (temperatureSlider != null)
        {
            temperatureSlider.minValue = minTemperature;
            temperatureSlider.maxValue = maxTemperature;
            temperatureSlider.value = currentTemperature; // Set the slider's initial value
        }

        playerStatsManager = FindObjectOfType<PlayerStatsManager>();
        timeController = FindObjectOfType<TimeController>();
    }

    void Update()
    {
        if (isNearHeatSource)
        {
            // Increase temperature near heat source
            currentTemperature = Mathf.Min(maxTemperature, currentTemperature + heatIncreaseRate * Time.deltaTime);
        }
        else
        {
            // Check for nighttime
            if (timeController != null)
            {
                float currentHour = (float)timeController.currentTime.TimeOfDay.TotalHours;
                bool isNightTime = currentHour >= 18 || currentHour < 6;

                if (isNightTime)
                {
                    // Decrease temperature during nighttime
                    currentTemperature = Mathf.Max(minTemperature, currentTemperature - temperatureDecreaseRate * Time.deltaTime);
                }
            }
        }

        // Update slider to reflect current temperature
        if (temperatureSlider != null)
        {
            temperatureSlider.value = currentTemperature;
        }

        // Handle damage if temperature is too low
        if (currentTemperature <= 0f && playerStatsManager != null)
        {
            playerStatsManager.DecreaseHealth(0.1f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HeatSource"))
        {
            isNearHeatSource = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("HeatSource"))
        {
            isNearHeatSource = false;
        }
    }
}
