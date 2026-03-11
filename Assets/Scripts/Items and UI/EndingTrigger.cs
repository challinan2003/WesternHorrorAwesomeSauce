using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using FMODUnity;
using FMOD.Studio;

public class EndingTrigger : MonoBehaviour
{
    public int KeyValue;
    public GameObject Ending;
    public GameObject fpsController;
    public KeyText keyText;
    public VideoPlayer finalCutscene;
    public Canvas videoCanvas;
    private bool videoTrigger = false;
    private float videoTimer;
    public RenderTexture renderTexture;

    void Update()
    {
        if (videoTrigger == true)
        {
            videoTimer += Time.deltaTime;
            print(videoTimer);
            if (videoTimer >= finalCutscene.length)
            {
                finalCutscene.Stop();
                renderTexture.Release();
                SceneManager.LoadScene(0);
            }
        }
        //KeyValue = GameObject.Find("StationKey").GetComponent<KeyText>().KeyCounter;
    }

        public void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                if (KeyValue == 1)
                {
                    finalCutscene.Play();
                    videoTrigger = true;
                    Debug.Log("Completed the level");
                    AudioManager.instance.PlayOneshot(FMODEvents.instance.FinalCS, this.transform.position);

            }
        }
            else
            {
                Debug.Log("not completed");
            }
        }
        
 }

