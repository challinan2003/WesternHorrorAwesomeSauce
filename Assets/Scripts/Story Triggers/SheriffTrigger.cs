using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class SheriffTrigger : MonoBehaviour
{
    public LayerMask Player;
    public VideoPlayer sheriffCutscene;
    public Canvas videoCanvas;
    private bool videoTrigger = false;
    private float videoTimer;
    public GameObject sheriffSet;
    public CanvasGroup sheriffCanvas;
    public RenderTexture renderTexture;
    public BartenderTrigger bartenderTrigger;
    public Madness madness;

    void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            sheriffCutscene.Play();
            videoTrigger = true;
            // AudioManager.instance.PlayOneshot(FMODEvents.instance.BartenderCS, this.transform.position);
        }
    }

    void Update()
    {
        if (videoTrigger == true)
        {
            madness.playerLocked = true;
            videoTimer += Time.deltaTime;
            if (videoTimer >= sheriffCutscene.length)
            {
                sheriffCutscene.Stop();
                sheriffCanvas.alpha = 0;
                madness.playerLocked = false;
                SceneManager.LoadScene(2);
            }
        }
    }


}