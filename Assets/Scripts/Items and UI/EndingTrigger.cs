using UnityEngine;

public class EndingTrigger : MonoBehaviour
{
    public int KeyValue;
    public GameObject Ending;
    public GameObject fpsController;
    // Update is called once per frame
    public void Update()
    {
        KeyValue = GameObject.Find("StationKey").GetComponent<KeyText>().KeyCounter;
    }

        public void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.tag == "Player")
        {
            if (KeyValue == 1)
        {
            fpsController.GetComponent<FirstPersonMovement>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Ending.SetActive(true);
            Debug.Log("Completed the level");
        }
        else
            {
                Debug.Log("not completed");
            }
        }
        
    }
}

