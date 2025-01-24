using UnityEngine;
using UnityEngine.EventSystems;  // Necessary for event triggers

public class ButtonHoverLogger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // This will log when the mouse hovers over the button
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Hover started over the button.");
    }

    // This will log when the mouse exits the button area
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Hover exited the button.");
    }
}
