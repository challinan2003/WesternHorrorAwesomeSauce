using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueSystem : MonoBehaviour
{

    //public Camera myCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        //get the mouse position
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(myCamera.transform.position, mousePosition-myCamera.transform.position, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                Debug.Log("we hit something");
            }
        }
    }

}
