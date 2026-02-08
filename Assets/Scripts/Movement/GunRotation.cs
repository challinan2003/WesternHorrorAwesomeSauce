using UnityEngine;

public class GunRotation : MonoBehaviour
{
    public Transform Camera;

    void Update()
    {

        transform.rotation = Camera.rotation;
    }
}