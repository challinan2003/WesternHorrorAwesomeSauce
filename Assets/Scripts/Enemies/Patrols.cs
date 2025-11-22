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
    public int enemyWalkSFX = 0;
    [Header("Movement Variables")]
        private bool canSeePlayer = false;
        private float sightTimerCountdown = 5f;
        public LayerMask Player;
        public LayerMask Bullet;

        public Transform chasePos;
        public Transform[] points;
        private int destPoint = 0;
        private UnityEngine.AI.NavMeshAgent agent;
        public Animator ZombieAnim;
    [Header("Health")]
    public int enemyHealth = 60;
    public GunSystem gunSystem;
    public GameObject EnemySFXObject;
    public GameObject SFXObject;
        
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
            //SoundManager.instance.PlaySFX(enemyWalkSFX);

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
        SFXObject = GameObject.Find("SFXOneShotPrefab(Clone)");
        //Player Spotted
        if (UnityEngine.Physics.Raycast(transform.position, transform.TransformDirection(UnityEngine.Vector3.forward), out RaycastHit hitinfo, 20f, Player))
        {
            sightTimerCountdown = 5;
            canSeePlayer = true;
            //SoundManager.instance.PlaySFX(enemyWalkSFX);
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

        if (enemyHealth <= 0)
        {
        
           SoundManager.instance.PlayAudioResource(Random.Range(5,7));
            
            Destroy(gameObject);
        }
    }
        
    void OnTriggerEnter(Collider bullet)
    {
        if (bullet.CompareTag("Bullet"))
        {
     
            SoundManager.instance.PlayAudioResource(Random.Range(0,3));
            
            UnityEngine.Debug.Log("bullet hit!");
            enemyHealth -= gunSystem.damage;
            UnityEngine.Debug.Log(enemyHealth);
            Destroy(bullet.gameObject);
        }
    }
}