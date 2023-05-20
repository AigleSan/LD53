using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bulletPrefab;
    public Transform shootPoint;

    public float bulletSpeed, shootCooldown, startShootCooldown;

    void Start() {
        //shootCooldown = startShootCooldown;
     }

    // Update is called once per frame
    void Update()
    {
        shootCooldown -= Time.deltaTime;
        if (Input.GetMouseButton(0) && shootCooldown <= 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
            //bullet.transform.position += transform.forward * speed * Time.deltaTime;
            bullet
                .GetComponent<Rigidbody>()
                .AddForce(shootPoint.forward * bulletSpeed, ForceMode.Force);
            shootCooldown = startShootCooldown;
        }
    }
}
