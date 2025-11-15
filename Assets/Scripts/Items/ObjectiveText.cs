using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ObjectiveText : MonoBehaviour
{
    public GameObject FirstObjective;
    public GameObject SecondObjective;
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.tag == "Player")
        {
            Debug.Log("changes objective");
            FirstObjective.SetActive(false);
            SecondObjective.SetActive(true);
        }
    }

}

