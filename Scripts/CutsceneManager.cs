using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public GameObject cutsceneCamera; // Drag your CutsceneCamera here
    public GameObject player;        // Drag your player GameObject here

    private Camera mainCamera;       // Reference to the Main Camera

    void Start()
    {
        // Find the Main Camera by its tag
        mainCamera = Camera.main;
        
        StartCutscene();
    }

    void StartCutscene()
    {
        // Enable the cutscene camera and disable the Main Camera
        cutsceneCamera.SetActive(true);
        if (mainCamera != null)
        {
            mainCamera.gameObject.SetActive(false);
        }

        // Optionally disable player controls here
        DisablePlayerControls();
    }

    void DisablePlayerControls()
    {
        // Example: Disable player movement script
        // Replace "PlayerMovement" with the actual script name used for movement
        if (player.TryGetComponent<PlayerMovement>(out PlayerMovement movement))
        {
            movement.enabled = false;
        }
    }
}
