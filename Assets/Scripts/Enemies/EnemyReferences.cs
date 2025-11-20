using UnityEngine;
using UnityEngine.AI;

public class EnemyReferences : MonoBehaviour
{
    public NavMeshAgent navMeshagent;
    public Animator EnemyAnimator;
    //public GameObject enemySFXPrefab;

    [Header("Stats")]

    public float pathUpdateDelay = 0.2f;

    private void Awake()
    {
        navMeshagent = GetComponent<NavMeshAgent>();
        EnemyAnimator = GetComponent<Animator>();
    } 
}
