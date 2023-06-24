using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public float shootCooldown, startShootCooldown, shootForce;

    public GameObject bullet;

    public Transform shootPoint;
    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = startShootCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (shootCooldown <= 0)
        {

            Shoot();
            shootCooldown = startShootCooldown;
        }
        else
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    private void Shoot()
    {

        Rigidbody rb = Instantiate(bullet, shootPoint.position, Quaternion.identity)
               .GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shootForce, ForceMode.Impulse);
    }
}
