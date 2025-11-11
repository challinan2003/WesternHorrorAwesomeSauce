using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.ComponentModel.Design;

public class DialogueSystem : MonoBehaviour
{

    [SerializeField] private string Letter1Tag = "Letter";
    [SerializeField] private string Letter2Tag = "Letter2";
    [SerializeField] private string Letter3Tag = "Letter3";
    [SerializeField] private string Letter4Tag = "Letter4";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    public GameObject Letter;
    public GameObject Letter2;
    public GameObject Letter3;
    public GameObject Letter4;

    public int Letter1SFX = 0;
     public int Letter2SFX = 0;
    public int Letter3SFX = 0;
    public int Letter4SFX = 0;
     
    public Object itemField;
    public GameObject fpsController;

    private Transform _selection;
    public GameObject SFXObject;

    // Update is called once per frame

    void Update()
    {
        SFXObject = GameObject.Find("SFXOneShotPrefab(Clone)");
        //SFXObject = GameObject.Find("SFXOneShotPrefab");
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(myCamera.transform.position, mousePosition-myCamera.transform.position, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(Letter1Tag))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (SFXObject == null)
                    {
                        // activates dialogue
                        var selectionRenderer = selection.GetComponent<Renderer>();
                        if (selectionRenderer != null)
                        {
                            Debug.Log("active letter");
                            Letter.SetActive(true);
                            //Time.timeScale = 0;
                            SoundManager.instance.PlaySFX(Letter1SFX);
                            StartDialogue();
                        }
                    }
                    _selection = selection;
                }
            }
            if (selection.CompareTag(Letter2Tag))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (SFXObject == null)
                    {
                        // activates dialogue
                        var selectionRenderer = selection.GetComponent<Renderer>();
                        if (selectionRenderer != null)
                        {
                            Debug.Log("active letter");
                            Letter2.SetActive(true);
                            //Time.timeScale = 0;
                            SoundManager.instance.PlaySFX(Letter2SFX);
                            StartDialogue();
                        }
                    }
                    _selection = selection;
                }
            }
            if (selection.CompareTag(Letter3Tag))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (SFXObject == null)
                    {
                        // activates dialogue
                        var selectionRenderer = selection.GetComponent<Renderer>();
                        if (selectionRenderer != null)
                        {
                            Debug.Log("active letter");
                            Letter3.SetActive(true);
                            //Time.timeScale = 0;
                            SoundManager.instance.PlaySFX(Letter3SFX);
                            StartDialogue();
                        }
                    }
                    _selection = selection;
                }
            }
        if (selection.CompareTag(Letter4Tag))
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            if (SFXObject == null)
                            {
                                // activates dialogue
                                var selectionRenderer = selection.GetComponent<Renderer>();
                                if (selectionRenderer != null)
                                {
                                    Debug.Log("active letter");
                                    Letter4.SetActive(true);
                                    //Time.timeScale = 0;
                                    SoundManager.instance.PlaySFX(Letter4SFX);
                                    StartDialogue();
                                }
                            }
                            _selection = selection;
                        }
                    }
            else
            {

            }
        }
    }

    public void EndDialogue()
    {
        Destroy(SFXObject);
       fpsController.GetComponent<FirstPersonMovement>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void StartDialogue()
    {
      fpsController.GetComponent<FirstPersonMovement>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
  
    }
}
