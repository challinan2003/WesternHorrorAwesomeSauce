using UnityEngine;
using UnityEngine.SceneManagement;
public class death : MonoBehaviour
{
    void awake()
    {
        Time.timeScale = 0;
    }

    void update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
}
