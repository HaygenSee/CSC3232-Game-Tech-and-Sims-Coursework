using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
// simple AI states with attacks in the same code
{
    private enum State {
        Idle,
        ChasePlayer,
        Attack,
    }

    [SerializeField]
    private Transform player;

    private float targetRange = 50f;
    private float attackRange = 30f;
    private NavMeshAgent navMeshAgent;
    private Vector3 startingPosition;
    private State state;
    public float range;
    public Transform centrePoint, bulletSpawn, enemy;
    public GameObject bulletPrefab;
    public float eBulletSpeed = 30f;

    public float cooldown = 1f;
    private float reload = 0f;
    
    void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        state = State.Idle;
    }

    private void Start() {
        startingPosition = transform.position;

    }

    void Update() {
        switch (state) {
            default:
            case State.Idle:
                Roam();
                FindTarget();
                break;

            case State.ChasePlayer:
                navMeshAgent.destination = player.position;
                returnToRoam();
                AttackPlayer();
                break;

            case State.Attack:
                AttackPlayer();
                returnToRoam();
                reload += Time.deltaTime;
                Roam();
                transform.LookAt(player);
                if (reload >= cooldown)
                {
                    shootPlayer();
                }
                
                break;
        }  
    }

    private void shootPlayer() 
        {
            var bullet = Instantiate(bulletPrefab, enemy.position, enemy.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * eBulletSpeed;
            reload = 0f;        
        }
    

    private void AttackPlayer() 
    {
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            state = State.Attack;
        }
    }

    private void returnToRoam() 
    {
        if (Vector3.Distance(transform.position, player.position) > targetRange)
        {
            Roam();
            state = State.Idle;
        }
    }

    private void FindTarget() 
    {
        if (Vector3.Distance(transform.position, player.position) < targetRange) 
        {
            navMeshAgent.destination = player.position;
            state = State.ChasePlayer;
        }
    }

    private void Roam()
    {
        if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point)) 
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                navMeshAgent.destination = point;
            }
        }
    }
    

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range; 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) 
        { 
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
