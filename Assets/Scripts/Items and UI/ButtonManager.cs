using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
 
    public GameObject Pausemenu;
    public bool isPaused;
    public int menusound;

    public void OnPlayButton()
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

    }
    public void OnPauseButton(bool state)
    {
        Debug.Log("time scale changed");
        Time.timeScale =  state ? 0:1;
        isPaused = state;
    }
}
