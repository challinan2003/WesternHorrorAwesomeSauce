using UnityEngine;

public class GunPosition : MonoBehaviour
{
    public Transform gunPosition;
    void Update()
    {
        transform.position = gunPosition.position;
    }
}
