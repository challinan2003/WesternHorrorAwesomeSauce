using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using FMOD.Studio;
using FMODUnity;
using System;

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
    public Madness madness;

     
    public UnityEngine.Object itemField;
    public GameObject fpsController;
    
    private Transform _selection;


    private EventInstance PlayLetter1;
    //private EventInstance PlayLetter5;
    //private EventInstance PlayLetter6;
    //private EventInstance PlayLetter7;
    public bool LetterEnd = false;
    PLAYBACK_STATE playbackState = PLAYBACK_STATE.STOPPED;
    private string letterevent = "event:/AllLetters";

    //FMOD.Studio.Bus MasterBus;
    private void Start()
    {
        //MasterBus = FMODUnity.RuntimeManager.GetBus("Bus:/music");
        //PlayLetter1 = AudioManager.instance.CreateEventInstance(FMODEvents.instance.Letter4);
        //PlayLetter1.getPlaybackState(out playbackState);
    }
    private void PlayRead(int letters)
    {
        EventInstance ReadLetter = RuntimeManager.CreateInstance(letterevent);
        ReadLetter.setParameterByName("Letters", letters);
        ReadLetter.start();
        ReadLetter.release();
        ReadLetter.getPlaybackState(out playbackState);
    }
    public void Update()
    {
    

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(Letter1Tag))
            {

                if (Input.GetKeyDown(KeyCode.E))
                {
                        if (playbackState == PLAYBACK_STATE.STOPPED)
                        {
                            //if (SFXObject == null)

                            // activates dialogue
                            var selectionRenderer = selection.GetComponent<Renderer>();
                            if (selectionRenderer != null)
                            {
                                madness.playerLocked = true;
                                Debug.Log("active letter");
                                Letter.SetActive(true);
                                PlayRead(1);

                                StartDialogue();

                            }
                            _selection = selection;
                    }

                }
                if (selection.CompareTag(Letter2Tag))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (playbackState == PLAYBACK_STATE.STOPPED)
                        {
                            //if (SFXObject == null)

                            // activates dialogue
                            var selectionRenderer = selection.GetComponent<Renderer>();
                            if (selectionRenderer != null)
                            {
                                madness.playerLocked = true;
                                Debug.Log("active letter");
                                Letter.SetActive(true);
                                PlayRead(2);

                                StartDialogue();

                            }
                            _selection = selection;
                        }

                    }

                }
                if (selection.CompareTag(Letter3Tag))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (playbackState == PLAYBACK_STATE.STOPPED)
                        {
                            //if (SFXObject == null)

                            // activates dialogue
                            var selectionRenderer = selection.GetComponent<Renderer>();
                            if (selectionRenderer != null)
                            {
                                madness.playerLocked = true;
                                Debug.Log("active letter");
                                Letter.SetActive(true);
                                PlayRead(3);

                                StartDialogue();

                            }
                            _selection = selection;
                        }

                    }
                }
                if (selection.CompareTag(Letter4Tag))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (playbackState == PLAYBACK_STATE.STOPPED)
                        {
                            //if (SFXObject == null)

                            // activates dialogue
                            var selectionRenderer = selection.GetComponent<Renderer>();
                            if (selectionRenderer != null)
                            {
                                madness.playerLocked = true;
                                Debug.Log("active letter");
                                Letter.SetActive(true);
                                PlayRead(4);

                                StartDialogue();

                            }
                            _selection = selection;
                        }

                    }
                }
            }
        }
    }

    public void EndDialogue()
    {
        Debug.Log("stopingsound");
        
        PlayRead(0);
        LetterEnd = true;


        Debug.Log("release controls");

        fpsController.GetComponent<FirstPersonMovement>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        madness.playerLocked = false;
    }
    
    public void StartDialogue()
    {
      fpsController.GetComponent<FirstPersonMovement>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        madness.playerLocked = true;
  
    }



}
