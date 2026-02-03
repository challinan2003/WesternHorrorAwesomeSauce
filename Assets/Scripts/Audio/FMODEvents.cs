using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("PlayerSFX")]
    [field: SerializeField] public EventReference DirtWalk {  get; set; }
    [field: Header("SFX")]
    [field: SerializeField] public EventReference GunShoot { get; set; }

    [field: SerializeField] public EventReference GunReload { get; set; }
    [field: SerializeField] public EventReference ItemPickup { get; set; }
 public static FMODEvents instance {  get; private set; }
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one FMOD  Events");
        }
        instance = this;
    }
}
