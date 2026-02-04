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
    public float recoveryTimer = 4f;
    [SerializeField] private float maxPlayerHealth = 100f;

    [Header("Splatter Effect")]
    [SerializeField] private UnityEngine.UI.Image redSplatterImage = null;

    [Header("Hurt Image")]
    [SerializeField] private UnityEngine.UI.Image hurtImage = null;
    [SerializeField] private float hurtTimer = 0.1f;

    //test for health
    public KeyCode loseHealth = KeyCode.Space;
    public GameObject Death;

    public LayerMask enemy;

    private void Start()
    {

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
            recoveryTimer = 5;
            recoveryTimer -= Time.deltaTime;
        }

        if (recoveryTimer >= 0)
        {
            recoveryTimer = 0;
            currentPlayerHealth += 1;
        }

    }


    public void TakeDamage()
    {
        if (currentPlayerHealth >= 0)
        {
            UpdateHealth();
        }
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            UnityEngine.Debug.Log("enemy attacking");
            TakeDamage();
        }
    }
}
