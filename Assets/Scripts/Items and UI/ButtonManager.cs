using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnPlayButton()
    {
        DOVirtual.DelayedCall(0.65f, () => SceneManager.LoadScene(1));
    }

    public void OnQuitButton()
    {
        DOVirtual.DelayedCall(1f, Application.Quit);
    }
}
