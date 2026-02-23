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

     
    public UnityEngine.Object itemField;
    public GameObject fpsController;
    
    private Transform _selection;


    private EventInstance PlayLetter1;
    //private EventInstance PlayLetter5;
    //private EventInstance PlayLetter6;
    //private EventInstance PlayLetter7;
    public bool LetterEnd = false;
    //PLAYBACK_STATE playbackState = PLAYBACK_STATE.STOPPED;
 
    //FMOD.Studio.Bus MasterBus;
    private void Start()
    {
        //MasterBus = FMODUnity.RuntimeManager.GetBus("Bus:/music");
        PlayLetter1 = AudioManager.instance.CreateEventInstance(FMODEvents.instance.Letter4);
        //PlayLetter1.getPlaybackState(out playbackState);
    }
    public void Update()
    {
    
        //playletter4 = audiomanager.instance.createeventinstance(fmodevents.instance.letter4);
        //playback_state playbackstate;
        //playletter4.getplaybackstate(out playbackstate);

        //playletter5 = audiomanager.instance.createeventinstance(fmodevents.instance.letter4);
        //playletter5.getplaybackstate(out playbackstate);

        //playletter6 = audiomanager.instance.createeventinstance(fmodevents.instance.letter4);
        //playletter6.getplaybackstate(out playbackstate);

        //playletter7 = audiomanager.instance.createeventinstance(fmodevents.instance.letter4);
        //playletter7.getplaybackstate(out playbackstate);


        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(Letter1Tag))
            {

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!LetterEnd)
                    {
                        PLAYBACK_STATE playbackState;
                        PlayLetter1.getPlaybackState(out playbackState);

                        if (playbackState == PLAYBACK_STATE.STOPPED)
                        {
                            //if (SFXObject == null)

                            // activates dialogue
                            var selectionRenderer = selection.GetComponent<Renderer>();
                            if (selectionRenderer != null)
                            {
                                //PlayLetter1 = AudioManager.instance.CreateEventInstance(FMODEvents.instance.Letter4);

                                Debug.Log("active letter");
                                Letter.SetActive(true);
                                PlayLetter1.start();
                                Time.timeScale = 1;

                                //PlayLetter1.release();
                                StartDialogue();

                            }
                            _selection = selection;
                        }
                    }
                    else if (LetterEnd)
                    {
                      PlayLetter1.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                      Letter.SetActive(false);

                    }
                }
                if (selection.CompareTag(Letter2Tag))
                {
                    if ((Input.GetKeyDown(KeyCode.E)))
                    {
                        //if (playbackState == PLAYBACK_STATE.STOPPED)
                        {
                            // activates dialogue
                            var selectionRenderer = selection.GetComponent<Renderer>();
                            if (selectionRenderer != null)
                            {
                                Debug.Log("active letter");
                                Letter2.SetActive(true);
                                Time.timeScale = 1;
                                //AudioManager.instance.PlayOneshot(FMODEvents.instance.Letter5, this.transform.position);
                                StartDialogue();
                            }
                        }
                        _selection = selection;
                    }
                    //{
                    //    if (SFXObject == null)
                    //    {
                    //        // activates dialogue
                    //        var selectionRenderer = selection.GetComponent<Renderer>();
                    //        if (selectionRenderer != null)
                    //        {
                    //            Debug.Log("active letter");
                    //            Letter2.SetActive(true);
                    //            Time.timeScale = 0;
                    //            AudioManager.instance.PlayOneshot(FMODEvents.instance.Letter5, this.transform.position);
                    //            StartDialogue();
                    //        }
                    //    }
                    //    _selection = selection;
                    //}
                }
                if (selection.CompareTag(Letter3Tag))
                {
                    if ((Input.GetKeyDown(KeyCode.E)))
                    {
                      
                        //if (playbackState == PLAYBACK_STATE.STOPPED)
                        {
                            // activates dialogue
                            var selectionRenderer = selection.GetComponent<Renderer>();
                            if (selectionRenderer != null)
                            {
                                Debug.Log("active letter");
                                Letter3.SetActive(true);
                                Time.timeScale = 0;
                               // AudioManager.instance.PlayOneshot(FMODEvents.instance.Letter6, this.transform.position);
                                StartDialogue();
                            }
                        }
                        _selection = selection;
                    }
                }
                if (selection.CompareTag(Letter4Tag))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        //if (playbackState == PLAYBACK_STATE.STOPPED)
                        
                            // activates dialogue
                            var selectionRenderer = selection.GetComponent<Renderer>();
                            if (selectionRenderer != null)
                            {
                                //PlayLetter4 = AudioManager.instance.CreateEventInstance(FMODEvents.instance.Letter4);
                                Debug.Log("active letter");
                                Letter.SetActive(true);
                                Time.timeScale = 1;
                                //PlayLetter4.start();
                                //PlayLetter4.release();
                                StartDialogue();
                            }
                        
                        _selection = selection;
                    }
                }
            }
        }
    }

    public void EndDialogue()
    {
        Debug.Log("stopingsound");
        LetterEnd = true;
        //if (playbackState != PLAYBACK_STATE.STOPPED)
        //{
        //    PlayLetter1.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        //}

        //PlayLetter5.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        //PlayLetter6.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        //PlayLetter7.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

        Debug.Log("release controls");

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
