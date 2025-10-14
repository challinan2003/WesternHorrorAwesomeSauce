using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class CloseRangeEnemy : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;
    private float distanceFromPlayer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = Vector3.Distance(agent.transform.position, player.position);
        agent.isStopped = false;
        agent.destination = player.position;
    }
}
