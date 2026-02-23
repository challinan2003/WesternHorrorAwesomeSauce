using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Collections;
using System.Configuration.Assemblies;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [Header("Player Health Amount")]
    public float currentPlayerHealth = 100f;
    public float recoveryTimer = 2f;
    [SerializeField] private float maxPlayerHealth = 100f;

    [Header("Splatter Effect")]
    [SerializeField] private UnityEngine.UI.Image redSplatterImage = null;

    [Header("Hurt Image")]
    [SerializeField] private UnityEngine.UI.Image hurtImage = null;
    [SerializeField] private float hurtTimer = 5f;

    //test for health
    //public KeyCode loseHealth = KeyCode.Space;
    public GameObject Death;

    public LayerMask enemy;

    private void Start()
    {
        UnityEngine.Color splatterAlpha = redSplatterImage.color;
        splatterAlpha.a = 0;
        redSplatterImage.color = splatterAlpha;
        UnityEngine.Color hurtAlpha = hurtImage.color;
        hurtAlpha.a = 0;
        hurtImage.color = hurtAlpha;
       
    }

    void Update()
    {
        UpdateHealth();

        if (currentPlayerHealth <= 0)
        {
            Death.SetActive(true);
            currentPlayerHealth = 0;
        }
    }

    void UpdateHealth()
    {
        UnityEngine.Color splatterAlpha = redSplatterImage.color;
        splatterAlpha.a = 1 - (currentPlayerHealth / maxPlayerHealth);
        redSplatterImage.color = splatterAlpha;

        UnityEngine.Color hurtAlpha = hurtImage.color;
        hurtAlpha.a = 1 - (currentPlayerHealth / maxPlayerHealth);
        hurtImage.color = hurtAlpha;

        if (currentPlayerHealth < 100)
        {
           recoveryTimer = 2f;
            recoveryTimer -= Time.deltaTime;
        }

        if (recoveryTimer >= 0)
        {
            recoveryTimer = 0;
            currentPlayerHealth += 1;
            currentPlayerHealth = Mathf.Clamp(currentPlayerHealth, 0, maxPlayerHealth);
        }

    }


    public void TakeDamage()
    {
        currentPlayerHealth -= 20f;
        if (currentPlayerHealth >= 0)
        {
            UpdateHealth();
        }
    }

    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            UnityEngine.Debug.Log("enemy attacking");
            TakeDamage();
        }
    }
}
