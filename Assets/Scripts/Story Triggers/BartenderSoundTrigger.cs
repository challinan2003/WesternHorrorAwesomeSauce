using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.SceneManagement;

public class BartenderSoundTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool videoTrigger = false;
    public LayerMask Player;
    void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            print("woah");
            videoTrigger = true;
            AudioManager.instance.PlayOneshot(FMODEvents.instance.BartenderCS, this.transform.position);

        }
    }
}
