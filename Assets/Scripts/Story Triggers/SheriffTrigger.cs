using UnityEngine;
using UnityEngine.Video;

public class SheriffTrigger : MonoBehaviour
{
    public LayerMask Player;
    public VideoPlayer sheriffCutscene;
    public Canvas sheriffVideoCanvas;
    private bool videoTrigger = false;
    private float videoTimer;
    public RenderTexture renderTexture;

    void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            print("woah");
            sheriffCutscene.Play();
            videoTrigger = true;
        }
    }

    void Update()
    {
        if (videoTrigger == true)
        {
            videoTimer += Time.deltaTime;
            if (videoTimer >= sheriffCutscene.length)
            {
                sheriffCutscene.Stop();
                renderTexture.Release();
            }
        }
    }

}
