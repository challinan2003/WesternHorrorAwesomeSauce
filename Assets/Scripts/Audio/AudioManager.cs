using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one audio manager");
        }
        instance = this; 
    }

    public void PlayOneshot(EventReference sound, Vector3 worldPos )
    {
        RuntimeManager.PlayOneShot(sound, worldPos);

    }
}
