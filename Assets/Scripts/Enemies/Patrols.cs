using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.Configuration.Assemblies;
using System.Drawing;
using System.Threading.Tasks;
using System.Numerics;
using UnityEngine.AI;
using System.Reflection;
using System.Runtime.InteropServices;


public class Patrols : MonoBehaviour 
{

    [Header("Movement Variables")]
        private bool canSeePlayer = false;
        private float sightTimerCountdown = 5f;
        public LayerMask Player;
        public Transform chasePos;
        public Transform[] points;
        private int destPoint = 0;
        private UnityEngine.AI.NavMeshAgent agent;
        public Animator ZombieAnim;
    [Header("Health")]
    public float enemyHealth = 3;
        
    public enum EnemyState
    {
        patrolling,
        chasingPlayer,
        idleling,
        dying,
        
    }
        



        void Start ()
        {
            ZombieAnim = GetComponent<Animator>();
            agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

            agent.autoBraking = false;

            GotoNextPoint();
        }


        void GotoNextPoint()
        {
            // Returns if no patrol points have been set up
            if (points.Length == 0)
                return;

            agent.destination = points[destPoint].position;
            //IT WAS THIS ONE
            destPoint = (destPoint + 1) % points.Length;
        }
        
        void IdleAtPosition()
        {
            
        }

        //Count Down timer when player is not seen
        void SightTimer()
        {
            sightTimerCountdown -= Time.deltaTime;
        }


        void Update()
        {
            //Player Spotted
            if (UnityEngine.Physics.Raycast(transform.position, transform.TransformDirection(UnityEngine.Vector3.forward), out RaycastHit hitinfo, 20f, Player))
            {
                sightTimerCountdown = 5;
                canSeePlayer = true;
            }
            
            //Enemy chases down player - Start Timer if enemy can no longer see player
            if (canSeePlayer == true)
            {
                agent.SetDestination(chasePos.position);
                SightTimer();
            }

            //Go back to patrol when the timer hits zero
            if (sightTimerCountdown <= 0)
            {
                canSeePlayer = false;
                GotoNextPoint();
                sightTimerCountdown = Random.Range(2, 6);
            }

            //When in patrol, if enemy doesn't see player, enemy moves to next position
            if (agent.remainingDistance < 1f && !canSeePlayer)
            {
                GotoNextPoint();
            }
        }
}