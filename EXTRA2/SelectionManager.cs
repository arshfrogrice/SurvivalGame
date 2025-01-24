using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
 
public class SelectionManager : MonoBehaviour
{
 
    public GameObject InteractionInfo;
    TextMeshProUGUI interaction_text;
    
 
    private void Start()
    {
        
        interaction_text = InteractionInfo.GetComponent<TextMeshProUGUI>();
    }
 
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;
            InteractableObjectt interactable = selectionTransform.GetComponent<InteractableObjectt>();
 
            if (interactable)
            {
                InteractionInfo.SetActive(true);
                interaction_text.text = interactable.GetItemName();
            }
            else 
            { 
                InteractionInfo.SetActive(false);
            }
 
        }
    }
}