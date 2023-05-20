using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform[] waypoints;
    private Transform target;
    private Transform player;

    public float moveSpeed,
        attackRange,
        sightRange;

    private int destPoint;

    Vector3 lastPosition;

    private float cooldown = 0f;
    public float startCooldown = 3f;

    void Awake()
    {
        target = waypoints[0];
        lastPosition = transform.position;
        player = GameObject.Find("Player").transform;
        //target = player;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dir = target.position - transform.position;

        if (
            Vector3.Distance(transform.position, player.position) < sightRange
            && Vector3.Distance(transform.position, player.position) >= attackRange
        )
        {
            //            supposons que ce soit le script d'un ennemi au corps à corps
           MoveTowardTarget(player);
        }
        else if (Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            if (cooldown <= 0)
            {
                //Attack();
                Debug.Log(gameObject.name + "Vient d'attaquer !");
                cooldown = startCooldown;
            }
            else
            {
                cooldown -= Time.deltaTime;
            }
        }
        else
        {
            MoveTowardTarget(target);
            if (Vector3.Distance(transform.position, target.position) < 0.3f) //on verifie si la distance entre l'ennemi et sa cible est inferieure  à 3
            {
                destPoint = (destPoint + 1) % waypoints.Length; //l'operateur % permet de recuperer le reste d'une division
                target = waypoints[destPoint];
            }
        }
    }

    public void MoveTowardTarget(Transform target)
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            moveSpeed * Time.deltaTime
        );

        transform.LookAt(target);
    }
}
