using FMOD.Studio;
using FMODUnity;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
   
    private List<EventInstance> eventInstances;
    public static AudioManager instance { get; private set; }
    //FMOD.Studio.Bus MasterBus;
    //freaking master bus bruh

    public void Start()
    {
        //MasterBus = FMODUnity.RuntimeManager.GetBus("bus:/Letters");
    }
    private void Awake()
    {


        if (instance != null)
        {
            Debug.LogError("Found more than one audio manager");
        }
        instance = this; 
        eventInstances = new List<EventInstance>();
    }

    public void PlayOneshot(EventReference sound, Vector3 worldPos )
    {
        RuntimeManager.PlayOneShot(sound, worldPos);

    }
    public EventInstance CreateEventInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(eventInstance);
        return eventInstance;
    }
    private void CleanUP()
    {
        foreach (EventInstance eventInstance in eventInstances)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }
    }
    private void OnDestroy()
    {  CleanUP(); }
}
