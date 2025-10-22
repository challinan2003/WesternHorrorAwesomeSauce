using System.Numerics;
using UnityEngine;

public class ProjectileRotation : MonoBehaviour
{
    [SerializeField] private UnityEngine.Vector3 _rotation;

    void Update()
    {
        transform.Rotate(_rotation * Time.deltaTime);
    } 
}
