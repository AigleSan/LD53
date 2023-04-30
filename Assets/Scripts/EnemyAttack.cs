using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform target,
        shootPoint;
    public GameObject bulletPrefab;
    public float attackRange,
        sightRange,
        movementSpeed,
        startCooldown,
        bulletSpeed;
    private float cooldown;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        while (Vector3.Distance(transform.position, target.position) > attackRange)
        {
            if (Vector3.Distance(transform.position, target.position) < sightRange)
            {
                transform.LookAt(target);
                //supposons que ce soit le script d'un ennemi au corps à corps
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    target.position,
                    movementSpeed * Time.deltaTime
                );
            }
        }

        if (Vector3.Distance(transform.position, target.position) <= attackRange)
        {
            if (cooldown <= 0)
            {
                Shoot();
                cooldown = startCooldown;
                Debug.Log("Il a attaqué");
            }
            else
            {
                cooldown -= Time.deltaTime;
            }
        }
    }

    void Shoot()
    {
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
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
