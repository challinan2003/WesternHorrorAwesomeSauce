using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using FMODUnity;
using FMOD.Studio;

public class BartenderTrigger : MonoBehaviour
{
    public LayerMask Player;     
    public VideoPlayer bartenderCutscene;
    public Canvas videoCanvas;
    private bool videoTrigger = false;
    private float videoTimer;
    public GameObject BartenderSet;
    public CanvasGroup bartenderCanvas;
    public RenderTexture renderTexture;

    void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            print("woah");
            bartenderCutscene.Play();
            videoTrigger = true;
           // AudioManager.instance.PlayOneshot(FMODEvents.instance.BartenderCS, this.transform.position);
        }
    }

    void Update()
    {
        if (videoTrigger == true)
        {
            videoTimer += Time.deltaTime;
            if (videoTimer >= bartenderCutscene.length)
            {
                bartenderCutscene.Stop();
                bartenderCanvas.alpha = 0;
                renderTexture.Release();
                SceneManager.LoadScene(2);
            }
        }
    }


}
