using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using FMODUnity;
using FMOD.Studio;
using Unity.VisualScripting;

public class Menu : MonoBehaviour
{
 
    public GameObject Pausemenu;
    public bool isPaused;
    public int menusound;
    public VideoPlayer firstCutscene;
    public Canvas videoCanvas;
    private bool videoTrigger = false;
    private float videoTimer;
    public GameObject MainMenuMuisc;

    public void OnPlayButton()
    {
        videoCanvas.sortingOrder = 150;
        firstCutscene.Play();
        Destroy(MainMenuMuisc);
        videoTrigger = true;
        AudioManager.instance.PlayOneshot(FMODEvents.instance.ProCS, this.transform.position);
        //DOVirtual.DelayedCall(0.65f, () => SceneManager.LoadScene(1));
    }

    private void GoToStartLevel()
    {
        DOVirtual.DelayedCall(0.65f, () => SceneManager.LoadScene(1));
    }


    public void OnQuitButton()
    {
        DOVirtual.DelayedCall(1f, Application.Quit);
    }

    public void OnRestartButton()
    {
        DOVirtual.DelayedCall(0.65f, () => SceneManager.LoadScene(0));
    }

    public void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.P) && !isPaused)
        {
             //SoundManager.instance.PlaySFX(menusound);
             Pausemenu.SetActive(true);
            Debug.Log("Pause menu");
            OnPauseButton(true);
 
        }
        else if(Input.GetKeyDown(KeyCode.P) && isPaused)
        {
            Debug.Log("Pause menu off");
             Pausemenu.SetActive(false);
            OnPauseButton(false);
        }

        //change level if video finishes

        if (firstCutscene.isPlaying && videoTrigger == true)
        {
            videoTimer += Time.deltaTime;
            if (videoTimer >= firstCutscene.length)
                GoToStartLevel();
        }
    }
    public void OnPauseButton(bool state)
    {
        Debug.Log("time scale changed");
        Time.timeScale =  state ? 0:1;
        isPaused = state;
    }
}
