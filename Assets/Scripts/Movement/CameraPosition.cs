using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Transform cameraPosition;
    void Start()
    {
        transform.position = cameraPosition.position;
    }
}
