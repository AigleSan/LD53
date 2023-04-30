using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform[] waypoints;
    private Transform target;

    public Animator anim;

    public float moveSpeed;

    public Transform player;

    private int destPoint;

    Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
        lastPosition = transform.position;
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        Vector3 velocity = (transform.position - lastPosition) / Time.deltaTime;
        lastPosition = transform.position;

        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.3f) //on verifie si la distance entre l'ennemi et sa cible est inferieure  à 3
        {
            destPoint = (destPoint + 1) % waypoints.Length; //l'operateur % permet de recuperer le reste d'une division
            target = waypoints[destPoint];
        }

        if (velocity.z >= 0.1f)
        {
            anim.Play("backWalk");
        }
        else if (velocity.z <= -0.1f)
        {
            anim.Play("frontWalk");
        }

        else if (velocity.x >= 0.1f && velocity.z == 0)
        {
            anim.Play("sideWalk");
        }

        else if (velocity.x <= -0.1f && velocity.z == 0)
        {
            anim.Play("sideWalkLeft");
            //graphics.flipY;
        }

        else{
            anim.Play("idle");
        }
    }
}
