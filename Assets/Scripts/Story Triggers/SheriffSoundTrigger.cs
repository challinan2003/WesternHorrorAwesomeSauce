using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using UnityEngine.SceneManagement;

public class SheriffSoundTrigger : MonoBehaviour
{
    private bool videoTrigger = false;
    public LayerMask Player;
    void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            print("woah");
            videoTrigger = true;
            AudioManager.instance.PlayOneshot(FMODEvents.instance.SheriffCS, this.transform.position);

        }
    }
}
