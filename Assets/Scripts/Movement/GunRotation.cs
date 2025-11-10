using UnityEngine;

public class GunRotation : MonoBehaviour
{
    public Transform camera;

    void Update()
    {

        transform.rotation = camera.rotation;
    }
}