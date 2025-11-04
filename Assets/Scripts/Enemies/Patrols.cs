using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Configuration.Assemblies;
using System.Drawing;
using System.Threading.Tasks;
using System.Numerics;
using UnityEngine.AI;


public class Patrols : MonoBehaviour 
{

    private bool canSeePlayer = false;
    private float sightTimer = 0;
    public LayerMask Player;
    public Transform chasePos;
        public Transform[] points;
        private int destPoint = 0;
        private UnityEngine.AI.NavMeshAgent agent;


        void Start () 
        {
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

            // Disabling auto-braking allows for continuous movement
            // between points (ie, the agent doesn't slow down as it
            // approaches a destination point).
            agent.autoBraking = false;

            GotoNextPoint();
        }


        void GotoNextPoint() 
        {
            // Returns if no points have been set up
            if (points.Length == 0)
                return;

            // Set the agent to go to the currently selected destination.
            agent.destination = points[destPoint].position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1) % points.Length;
        }


    void Update()
    {
        if (UnityEngine.Physics.Raycast(transform.position, transform.TransformDirection(UnityEngine.Vector3.forward), out RaycastHit hitinfo, 20f, Player))
        {
            UnityEngine.Debug.Log("Hit Player");
            canSeePlayer = true;
        }
        
        if (canSeePlayer == true)
        {
            agent.SetDestination(chasePos.position);
        }
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (agent.remainingDistance < 1f && !canSeePlayer)
        {
            GotoNextPoint();
        }
    }
}