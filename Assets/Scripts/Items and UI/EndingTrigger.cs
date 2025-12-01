using UnityEngine;

public class EndingTrigger : MonoBehaviour
{
    public int KeyValue;
    public GameObject Ending;
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

