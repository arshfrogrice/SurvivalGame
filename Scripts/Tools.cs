using UnityEngine;

public class Tool : MonoBehaviour
{
    public string toolName; // Name of the tool (e.g., "Axe")
    public GameObject toolPrefab; // The 3D model of the tool
    public Vector3 toolPositionOffset; // Position offset when equipped
    public Vector3 toolRotationOffset; // Rotation offset when equipped
}
