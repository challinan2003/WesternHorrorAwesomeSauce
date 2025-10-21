using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class DialogueSystem : MonoBehaviour
{

    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    public GameObject Letter;



    public Object itemField;

    private Transform _selection;
    // Update is called once per frame
    void Update()
    {
        if (_selection != null)
        {
            //deactivate dialogue
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(myCamera.transform.position, mousePosition-myCamera.transform.position, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    // activates dialogue
                    var selectionRenderer = selection.GetComponent<Renderer>();
                    if (selectionRenderer != null)
                    {
                            Debug.Log("active letter");
                           Letter.SetActive(true);
                        }
                    }
                    _selection = selection;
                }
            }
        }
    }