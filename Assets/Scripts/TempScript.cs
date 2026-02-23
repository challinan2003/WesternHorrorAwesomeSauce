using FMOD.Studio;
using UnityEngine;

public class TempScript : MonoBehaviour
{
    //public GameObject Letter;
    //public GameObject Letter2;
    //public GameObject Letter3;
    //public GameObject Letter4;

    ////public int Letter1SFX = 0;
    ////public int Letter2SFX = 0;
    ////public int Letter3SFX = 0;
    ////public int Letter4SFX = 0;

    //public UnityEngine.Object itemField;
    //public GameObject fpsController;

    //private Transform _selection;
    ////public GameObject SFXObject;
    //private EventInstance PlayLetter1;
    ////private EventInstance PlayLetter5;
    ////private EventInstance PlayLetter6;
    ////private EventInstance PlayLetter7;
    ////public bool LetterEnd = false;
    //PLAYBACK_STATE playbackState = PLAYBACK_STATE.STOPPED;

    ////FMOD.Studio.Bus MasterBus;
    //private void Start()
    //{
    //    //MasterBus = FMODUnity.RuntimeManager.GetBus("Bus:/music");

    //}
    //public void Update()
    //{

    //    //playletter4 = audiomanager.instance.createeventinstance(fmodevents.instance.letter4);
    //    //playback_state playbackstate;
    //    //playletter4.getplaybackstate(out playbackstate);

    //    //playletter5 = audiomanager.instance.createeventinstance(fmodevents.instance.letter4);
    //    //playletter5.getplaybackstate(out playbackstate);

    //    //playletter6 = audiomanager.instance.createeventinstance(fmodevents.instance.letter4);
    //    //playletter6.getplaybackstate(out playbackstate);

    //    //playletter7 = audiomanager.instance.createeventinstance(fmodevents.instance.letter4);
    //    //playletter7.getplaybackstate(out playbackstate);




    //    //SFXObject = GameObject.Find("SFXOneShotPrefab(Clone)");
    //    //SFXObject = GameObject.Find("SFXOneShotPrefab");
    //    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    //Debug.DrawRay(myCamera.transform.position, mousePosition-myCamera.transform.position, Color.green);
    //    RaycastHit hit;
    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        var selection = hit.transform;
    //        if (selection.CompareTag(Letter1Tag))
    //        {
    //            //PlayLetter4 = AudioManager.instance.CreateEventInstance(FMODEvents.instance.Letter4);
    //            //PLAYBACK_STATE playbackState;
    //            //PlayLetter4.getPlaybackState(out playbackState);
    //            if (Input.GetKeyDown(KeyCode.E))
    //            {

    //                if (playbackState == PLAYBACK_STATE.STOPPED)
    //                {
    //                    //if (SFXObject == null)

    //                    // activates dialogue
    //                    var selectionRenderer = selection.GetComponent<Renderer>();
    //                    if (selectionRenderer != null)
    //                    {
    //                        PlayLetter1 = AudioManager.instance.CreateEventInstance(FMODEvents.instance.Letter4);
    //                        //playbackState = PLAYBACK_STATE.PLAYING;
    //                        Debug.Log("active letter");
    //                        Letter.SetActive(true);
    //                        PlayLetter1.start();
    //                        Time.timeScale = 1;

    //                        //PlayLetter1.release();
    //                        StartDialogue();

    //                    }
    //                    _selection = selection;
    //                }
    //            }
    //            if (selection.CompareTag(Letter2Tag))
    //            {
    //                if ((Input.GetKeyDown(KeyCode.E)))
    //                {
    //                    //if (playbackState == PLAYBACK_STATE.STOPPED)
    //                    {
    //                        // activates dialogue
    //                        var selectionRenderer = selection.GetComponent<Renderer>();
    //                        if (selectionRenderer != null)
    //                        {
    //                            Debug.Log("active letter");
    //                            Letter2.SetActive(true);
    //                            Time.timeScale = 1;
    //                            //AudioManager.instance.PlayOneshot(FMODEvents.instance.Letter5, this.transform.position);
    //                            StartDialogue();
    //                        }
    //                    }
    //                    _selection = selection;
    //                }
    //                //{
    //                //    if (SFXObject == null)
    //                //    {
    //                //        // activates dialogue
    //                //        var selectionRenderer = selection.GetComponent<Renderer>();
    //                //        if (selectionRenderer != null)
    //                //        {
    //                //            Debug.Log("active letter");
    //                //            Letter2.SetActive(true);
    //                //            Time.timeScale = 0;
    //                //            AudioManager.instance.PlayOneshot(FMODEvents.instance.Letter5, this.transform.position);
    //                //            StartDialogue();
    //                //        }
    //                //    }
    //                //    _selection = selection;
    //                //}
    //            }
    //            if (selection.CompareTag(Letter3Tag))
    //            {
    //                if ((Input.GetKeyDown(KeyCode.E)))
    //                {

    //                    //if (playbackState == PLAYBACK_STATE.STOPPED)
    //                    {
    //                        // activates dialogue
    //                        var selectionRenderer = selection.GetComponent<Renderer>();
    //                        if (selectionRenderer != null)
    //                        {
    //                            Debug.Log("active letter");
    //                            Letter3.SetActive(true);
    //                            Time.timeScale = 0;
    //                            // AudioManager.instance.PlayOneshot(FMODEvents.instance.Letter6, this.transform.position);
    //                            StartDialogue();
    //                        }
    //                    }
    //                    _selection = selection;
    //                }
    //            }
    //            if (selection.CompareTag(Letter4Tag))
    //            {
    //                if (Input.GetKeyDown(KeyCode.E))
    //                {
    //                    //if (playbackState == PLAYBACK_STATE.STOPPED)

    //                    // activates dialogue
    //                    var selectionRenderer = selection.GetComponent<Renderer>();
    //                    if (selectionRenderer != null)
    //                    {
    //                        //PlayLetter4 = AudioManager.instance.CreateEventInstance(FMODEvents.instance.Letter4);
    //                        Debug.Log("active letter");
    //                        Letter.SetActive(true);
    //                        Time.timeScale = 1;
    //                        //PlayLetter4.start();
    //                        //PlayLetter4.release();
    //                        StartDialogue();
    //                    }

    //                    _selection = selection;
    //                }
    //            }
    //        }
    //    }
    //}

    //public void EndDialogue()
    //{
    //    Debug.Log("stopingsound");
    //    //PlayLetter1.release();
    //    if (playbackState == PLAYBACK_STATE.PLAYING)
    //    {
    //        PlayLetter1.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    //    }
    //    // PlayLetter1.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    //    playbackState = PLAYBACK_STATE.STOPPED;
    //    if (playbackState == PLAYBACK_STATE.STOPPED)
    //    {
    //        Debug.Log("State stopped");
    //        PlayLetter1.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);

    //    }
    //    //PlayLetter5.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    //    //PlayLetter6.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    //    //PlayLetter7.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    //    //Destroy(SFXObject);
    //    //LetterEnd = true;
    //    Debug.Log("release controls");

    //    fpsController.GetComponent<FirstPersonMovement>().enabled = true;
    //    Cursor.visible = false;
    //    Cursor.lockState = CursorLockMode.Locked;
    //}

    //public void StartDialogue()
    //{
    //    fpsController.GetComponent<FirstPersonMovement>().enabled = false;
    //    Cursor.visible = true;
    //    Cursor.lockState = CursorLockMode.Confined;

    //}



}
