using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround,
        whatIsPlayer;

    Collider collider;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking

    public float timeBetweenAttacks,
        shootForce,
        rushSpeed,
        afterRushWaitTime;

        public int rushDamage;

    bool alreadyAttacked,
        isRushing;

    public GameObject projectile;

    //States
    public float sightRange,
        attackRange;

    public bool playerInSightRange,
        playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        collider = GetComponent<Collider>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
            Patroling();
        if (playerInSightRange && !playerInAttackRange)
            ChasePlayer();
        if (playerInAttackRange && playerInSightRange)
           ShootPlayer(player.position);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude <= 0.1f)
            walkPointSet = false;
    }

    private void Patroling()
    {
        if (!walkPointSet)
            SearchWalkPoint();

        if (walkPointSet)
            Debug.Log("Patroling");
        agent.SetDestination(walkPoint);
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);

        transform.LookAt(player);
    }

    private void ShootPlayer(Vector3 targetPos)
    {
        agent.SetDestination(transform.position);
        transform.LookAt(targetPos);

        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity)
                .GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * shootForce, ForceMode.Impulse);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    IEnumerator RushPlayer(Vector3 targetPos)
    {
        //transform.position = targetPos;
        collider.isTrigger = true;
        isRushing = true;
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPos,
            rushSpeed * Time.deltaTime
        );
        yield return new WaitForSeconds(afterRushWaitTime);
        collider.isTrigger = false;
        isRushing = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(
            transform.position.x + randomX,
            transform.position.y,
            transform.position.z + randomZ
        );

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, sightRange);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") { 
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(rushDamage);

        }
    }
}
