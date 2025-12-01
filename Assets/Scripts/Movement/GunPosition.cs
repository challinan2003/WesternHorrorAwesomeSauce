using UnityEngine;

public class GunPosition : MonoBehaviour
{
    public Transform gunPosition;
    void Start()
    {
        transform.position = gunPosition.position;
    }
}
