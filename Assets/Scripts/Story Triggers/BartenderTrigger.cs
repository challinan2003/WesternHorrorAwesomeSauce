using UnityEngine;
using UnityEngine.Video;
using FMODUnity;
using FMOD.Studio;

public class BartenderTrigger : MonoBehaviour
{
    public LayerMask Player;     
    public VideoPlayer bartenderCutscene;
    public Canvas videoCanvas;
    public bool videoTriggerBartender = false;
    private float videoTimer;
    public GameObject BartenderSet;
    public CanvasGroup bartenderCanvas;
    public RenderTexture renderTexture;

    void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            bartenderCutscene.Play();
            videoTriggerBartender = true;
           // AudioManager.instance.PlayOneshot(FMODEvents.instance.BartenderCS, this.transform.position);
        }
    }

    void Update()
    {
        if (videoTriggerBartender == true)
        {
            videoTimer += Time.deltaTime;
            if (videoTimer >= bartenderCutscene.length)
            {
                bartenderCutscene.Stop();
                bartenderCanvas.alpha = 0;
                renderTexture.Release();
                Destroy(BartenderSet);
            }
        }
    }


}