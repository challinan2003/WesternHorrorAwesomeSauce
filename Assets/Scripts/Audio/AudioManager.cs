using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    private List<EventInstance> eventInstances;
    public static AudioManager instance { get; private set; }
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
