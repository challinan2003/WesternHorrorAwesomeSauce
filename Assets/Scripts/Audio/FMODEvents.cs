using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("PlayerSFX")]
    [field: SerializeField] public EventReference dirtWalk {  get; set; }
    [field: Header("SFX")]
    [field: SerializeField] public EventReference gunShoot { get; set; }

    [field: SerializeField] public EventReference gunReload { get; set; }
    [field: SerializeField] public EventReference itemPickup { get; set; }
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
