using System.Numerics;
using UnityEngine;

public class GunSway : MonoBehaviour
{
    [Header("Sway")]
    [SerializeField] private float smooth;
    [SerializeField] private float swayMultiplier;

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * swayMultiplier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * swayMultiplier;

        UnityEngine.Quaternion rotationY = UnityEngine.Quaternion.AngleAxis(-mouseY, UnityEngine.Vector3.right);
        UnityEngine.Quaternion rotationX = UnityEngine.Quaternion.AngleAxis(mouseX, UnityEngine.Vector3.up);

        UnityEngine.Quaternion targetRotation = rotationX * rotationY;

        transform.localRotation = UnityEngine.Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);

    }
}
