using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Letters")]
    [field: SerializeField] public EventReference Letter4 { get; set; }
    [field: SerializeField] public EventReference Letter5 { get; set; }
    [field: SerializeField] public EventReference Letter6 { get; set; }
    [field: SerializeField] public EventReference Letter7 { get; set; }
    [field: Header("EnemySFX")]
    [field: SerializeField] public EventReference EnemyAlert {  get; set; }
    [field: SerializeField] public EventReference EnemyDeath { get; set; }
    [field: SerializeField] public EventReference EnemyHurt { get; set; }
    [field: Header("PlayerSFX")]
    [field: SerializeField] public EventReference DirtWalk {  get; set; }
    [field: Header("SFX")]
    [field: SerializeField] public EventReference GunShoot { get; set; }

    [field: SerializeField] public EventReference GunReload { get; set; }
    [field: SerializeField] public EventReference ItemPickup { get; set; }
    [field: SerializeField] public EventReference PlayerDrink { get; set; }
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
