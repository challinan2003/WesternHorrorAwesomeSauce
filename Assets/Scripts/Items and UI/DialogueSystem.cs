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

    //public int Letter1SFX = 0;
    //public int Letter2SFX = 0;
    //public int Letter3SFX = 0;
    //public int Letter4SFX = 0;
     
    public UnityEngine.Object itemField;
    public GameObject fpsController;
    
    private Transform _selection;
    //public GameObject SFXObject;
    private EventInstance PlayLetter4;
    private EventInstance PlayLetter5;
    private EventInstance PlayLetter6;
    private EventInstance PlayLetter7;
    //public bool LetterEnd = false;

    FMOD.Studio.Bus MasterBus;
    private void Start()
    {
        MasterBus = FMODUnity.RuntimeManager.GetBus("Bus:/music");
    }
    public void Update()
    {
        PlayLetter4 = AudioManager.instance.CreateEventInstance(FMODEvents.instance.Letter4);
        PLAYBACK_STATE playbackState;
        PlayLetter4.getPlaybackState(out playbackState);

        PlayLetter5 = AudioManager.instance.CreateEventInstance(FMODEvents.instance.Letter4);
        PlayLetter5.getPlaybackState(out playbackState);

        PlayLetter6 = AudioManager.instance.CreateEventInstance(FMODEvents.instance.Letter4);
        PlayLetter6.getPlaybackState(out playbackState);

                            PlayLetter7 = AudioManager.instance.CreateEventInstance(FMODEvents.instance.Letter4);
                    PlayLetter7.getPlaybackState(out playbackState);




        //SFXObject = GameObject.Find("SFXOneShotPrefab(Clone)");
        //SFXObject = GameObject.Find("SFXOneShotPrefab");
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(myCamera.transform.position, mousePosition-myCamera.transform.position, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(Letter1Tag))
            {
                //PlayLetter4 = AudioManager.instance.CreateEventInstance(FMODEvents.instance.Letter4);
                //PLAYBACK_STATE playbackState;
                //PlayLetter4.getPlaybackState(out playbackState);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (playbackState == PLAYBACK_STATE.STOPPED)
                    //if (SFXObject == null)
                    {
                        // activates dialogue
                        var selectionRenderer = selection.GetComponent<Renderer>();
                        if (selectionRenderer != null)
                        {
                            Debug.Log("active letter");
                            Letter.SetActive(true);
                            Time.timeScale = 0;
                            PlayLetter4.start();
                            //PlayLetter4.release();
                            StartDialogue();
                            
                        }
                        _selection = selection;
                    }
                }
                if (selection.CompareTag(Letter2Tag))
                {
                    if ((Input.GetKeyDown(KeyCode.E)))
                    {
                        if (playbackState == PLAYBACK_STATE.STOPPED)
                        {
                            // activates dialogue
                            var selectionRenderer = selection.GetComponent<Renderer>();
                            if (selectionRenderer != null)
                            {
                                Debug.Log("active letter");
                                Letter2.SetActive(true);
                                Time.timeScale = 0;
                                AudioManager.instance.PlayOneshot(FMODEvents.instance.Letter5, this.transform.position);
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
                      
                        if (playbackState == PLAYBACK_STATE.STOPPED)
                        {
                            // activates dialogue
                            var selectionRenderer = selection.GetComponent<Renderer>();
                            if (selectionRenderer != null)
                            {
                                Debug.Log("active letter");
                                Letter3.SetActive(true);
                                Time.timeScale = 0;
                                AudioManager.instance.PlayOneshot(FMODEvents.instance.Letter6, this.transform.position);
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
                        if (playbackState == PLAYBACK_STATE.STOPPED)
                        {
                            // activates dialogue
                            var selectionRenderer = selection.GetComponent<Renderer>();
                            if (selectionRenderer != null)
                            {
                                Debug.Log("active letter");
                                Letter4.SetActive(true);
                                Time.timeScale = 0;
                                AudioManager.instance.PlayOneshot(FMODEvents.instance.Letter7, this.transform.position);
                                StartDialogue();
                            }
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
        MasterBus.stopAllEvents(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        //PlayLetter4.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        //PlayLetter5.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        //PlayLetter6.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        //PlayLetter7.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        //Destroy(SFXObject);
        //LetterEnd = true;
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
