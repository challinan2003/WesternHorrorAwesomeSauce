using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ObjectiveText : MonoBehaviour
{
    public TextMeshProUGUI FirstObjective;
    //public GameObject SecondObjective;
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("changes objective");
            FirstObjective.text = "Find the station key";
        }

    }

}

