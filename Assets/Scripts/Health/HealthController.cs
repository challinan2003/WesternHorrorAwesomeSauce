using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [Header("Player Health Amount")]
    public float currentPlayerHealth = 100f;
    [SerializeField] private float maxPlayerHealth = 100f;

    [Header("Splatter Effect")]
    [SerializeField] private UnityEngine.UI.Image redSplatterImage = null;

    [Header("Hurt Image")]
    [SerializeField] private UnityEngine.UI.Image hurtImage = null;
    [SerializeField] private float hurtTimer = 0.1f;

    private void Start()
    {

    }

    void UpdateHealth()
    {
        Color splatterAlpha = redSplatterImage.color;
        splatterAlpha.a = 1 - (currentPlayerHealth / maxPlayerHealth);
        redSplatterImage.color = splatterAlpha;
    }

    public void TakeDamage()
    {
        if(currentPlayerHealth >= 0 )
        {
            UpdateHealth();
        }
    }
}
