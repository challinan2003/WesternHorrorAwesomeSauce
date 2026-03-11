using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

 public void OnTriggerEnter(Collider collision)
        {
        if (collision.gameObject.tag == "Player")
            {
                SceneManager.LoadScene(2);
            }
        }
}