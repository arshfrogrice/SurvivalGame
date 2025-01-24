using UnityEngine;

public class BookPanelHandler : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false); // Hide the BookPanel
            Time.timeScale = 1f; // Resume the game
        }
    }
}
