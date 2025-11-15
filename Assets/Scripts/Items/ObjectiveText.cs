using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ObjectiveText : MonoBehaviour
{
    public TextMeshProUGUI Objective;

    void Update()
    {
        //Objective = GetComponent<TMP_Text>();
        // Start is called once before the first execution of Update after the MonoBehaviour is create
       //Objective.text = "Find the Railway Station";
    }

    // Update is called once per frame
            private void OnTriggerEnter()
        {
                Objective.SetText("Find the Station Key");
        }
    }
