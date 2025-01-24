using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempScript : MonoBehaviour
{
    public Slider slider;  // Reference to the temperature slider

    // Set the max temperature and initialize the slider
    public void SetMaxTemperature(float temperature)
    {
        slider.maxValue = temperature;
        slider.value = temperature; // Set the initial value to the max temperature
    }

    // Set the current temperature
    public void SetTemperature(float temperature)
    {
        slider.value = temperature;  // Update the slider to the current temperature
    }
}
