using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public Slider volumeSlider;  // Reference to the UI Slider
    public AudioSource musicSource; // Reference to the AudioSource playing music

    void Start()
    {
        // Set the slider value to the current music volume
        if (musicSource != null && volumeSlider != null)
        {
            volumeSlider.value = musicSource.volume;
        }

        // Add listener to handle value changes
        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.AddListener(SetMusicVolume);
        }
    }

    public void SetMusicVolume(float volume)
    {
        if (musicSource != null)
        {
            musicSource.volume = volume; // Update the AudioSource volume
        }
    }
}
