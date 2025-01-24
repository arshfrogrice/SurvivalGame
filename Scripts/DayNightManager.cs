using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Material skyboxMaterial; // Assign your skybox material here
    private Material runtimeMaterial; // Runtime instance of the material
    public float dayDuration = 1440f; // Total duration of the day in seconds
    public float timeScale = 1f; // Multiplier for speeding up/slowing down time

    public float nightStartTime = 1110f; // Time in seconds (18:30 converted to seconds)
    public float dayStartTime = 360f; // Time in seconds (6:00 converted to seconds)

    private float currentTime = 0f; // Tracks the current time in the cycle

    void Start()
    {
        runtimeMaterial = new Material(skyboxMaterial);
        RenderSettings.skybox = runtimeMaterial;
    }

    void Update()
    {
        currentTime += Time.deltaTime * timeScale;
        if (currentTime > dayDuration) currentTime = 0;

        float blendValue = Mathf.InverseLerp(0, dayDuration, currentTime);
        runtimeMaterial.SetFloat("Blend_Value", blendValue);
    }

    public bool IsNight()
    {
        return currentTime >= nightStartTime || currentTime < dayStartTime;
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }
    public float GetCurrentHour()
    {
        return (currentTime / dayDuration) * 24f; // Convert the current time to hours in a 24-hour format
    }
}
