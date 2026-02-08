using System.Data.Common;
using System.IO;
using System.Numerics;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
//using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;

public class EnemyStates : MonoBehaviour
{
    public Transform Player;
    private EnemyReferences EnemyReferences;
    private float attackingDistance;

    private float pathUpdateDeadline;

    private void Awake()
    {
        EnemyReferences = GetComponent<EnemyReferences>();
    }
    void Start()
    {
        attackingDistance = EnemyReferences.navMeshagent.stoppingDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            bool inRange = UnityEngine.Vector3.Distance(transform.position, Player.position) <= attackingDistance;

            if (inRange)
            {
                LookAtPlayer();
            }
            else
            {
                UpdatePath();
            }
        }
    }

    private void LookAtPlayer()
    {
        UnityEngine.Vector3 lookPosition = Player.position - transform.position;
        lookPosition.y = 0;
        UnityEngine.Quaternion rotation = UnityEngine.Quaternion.LookRotation(lookPosition);
        transform.rotation = UnityEngine.Quaternion.Slerp(transform.rotation, rotation, 0.2f);
    }
        private void UpdatePath()
    {
        if (Time.time >= pathUpdateDeadline)
        {
            Debug.Log("updating path");
            pathUpdateDeadline = Time.time + EnemyReferences.pathUpdateDelay;
            EnemyReferences.navMeshagent.SetDestination(Player.position);
        }
    }
}
