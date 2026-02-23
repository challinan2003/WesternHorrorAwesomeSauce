using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class KeyText : MonoBehaviour
{
    public TextMeshProUGUI FirstObjective;
    public int pickupSFX = 0;

    public int KeyCounter = 0;
    public EndingTrigger endingTrigger;
    
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.tag == "Player")
        {
            KeyCounter = 1;
            endingTrigger.KeyValue = 1;
            Debug.Log("changes objective again");
            FirstObjective.text = "Return to the Station";
            Destroy(gameObject);
            //SoundManager.instance.PlaySFX(pickupSFX);
        }

    }

}