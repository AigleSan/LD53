using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public Transform[] waypoints;
    private Transform target;

    public Transform shootPoint;

    private Transform player;

    public GameObject bulletPrefab;

    public Animator anim;

    public float moveSpeed,
        shootRange,
        sightRange,
        startCooldown,
        bulletSpeed;

    private float cooldown;

    private int destPoint;

    Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
        lastPosition = transform.position;
        anim = GetComponentInChildren<Animator>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        Vector3 velocity = (transform.position - lastPosition) / Time.deltaTime;
        lastPosition = transform.position;

        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length; //l'operateur % permet de recuperer le reste d'une division
            target = waypoints[destPoint];
        }

        if (Vector3.Distance(transform.position, player.position) >= sightRange)
        {
            transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
        }
        else if (Vector3.Distance(transform.position, player.position) < sightRange)
        {
            //while (Vector3.Distance(transform.position, player.position) > shootRange)
           // {
                transform.LookAt(player);
                //supposons que ce soit le script d'un ennemi au corps à corps
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    player.position,
                    moveSpeed * Time.deltaTime
                );
            //}
        }
        else if (Vector3.Distance(transform.position, player.position) <= shootRange)
        {
            if (cooldown <= 0)
            {
                //Shoot();
                cooldown = startCooldown;
                Debug.Log("Il a attaqué");
            }
            else
            {
                cooldown -= Time.deltaTime;
            }
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
        else
        {
            anim.Play("idle");
        }
    }

    void Shoot()
    {
        Debug.Log("Ca tire");
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        //bullet.transform.position += transform.forward * speed * Time.deltaTime;
        bullet
            .GetComponent<Rigidbody>()
            .AddForce(shootPoint.forward * bulletSpeed, ForceMode.Force);
        //shootCooldown = startShootCooldown;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 0, 1, 1);
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = new Color(1, 0, 0, 1);
        Gizmos.DrawWireSphere(transform.position, shootRange);
    }

    private void OnCollsionEnter(Collision other) {
        if (other.gameObject.tag == ("Player")){
                SceneManager.LoadScene("GameOver");
                Debug.Log(other.gameObject.name + " touché !");
        }

        if (other.gameObject.tag == ("Obstacle")){
            Physics.IgnoreCollision(other.collider, this.gameObject.GetComponent<Collider>());
        }
        
    }
}
