using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingTrigger : MonoBehaviour
{
    public int KeyValue;
    public GameObject Ending;
    public GameObject fpsController;
    public KeyText keyText;
    // Update is called once per frame
    public void Update()
    {
        //KeyValue = GameObject.Find("StationKey").GetComponent<KeyText>().KeyCounter;
    }

        public void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.tag == "Player")
        {
            if (KeyValue == 1)
        {
            SceneManager.LoadScene(3);
            Debug.Log("Completed the level");
        }
        else
            {
                Debug.Log("not completed");
            }
        }
        
    }
}

