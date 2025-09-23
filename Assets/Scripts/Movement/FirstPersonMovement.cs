using UnityEngine;
using UnityEngine.Rendering;

public class FirstPersonMovement : MonoBehaviour
{
    public float xSens;
    public float ySens;

    public Transform orientation;

    float xRotation;
    float yRotation;

    void Start()
    {
        //Lock Cursor at beginning and make it not visible to player on start up
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        //Get Mouse input and adjust look speed to the players sensitivity
        float xMouse = Input.GetAxisRaw("Mouse X") * Time.deltaTime * xSens;
        float yMouse = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * ySens;


        yRotation += xMouse;
        xRotation -= yMouse;

        //Lock look height to floor and sky 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate camera
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        //rotate player along y axis
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
