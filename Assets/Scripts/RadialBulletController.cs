using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialBulletController : MonoBehaviour
{
    // Start is called before the first frame update

    public int numberOfProjectiles;
    public float projectileSpeed;

    private float projectileSpawnRate;

    public float projectileSpawnStartRate;
    public GameObject ProjectilePrefab;

    private Vector3 startPoint;

    private const float radius = 1f;

    void Start()
    {
        projectileSpawnRate = projectileSpawnStartRate;
    }

    // Update is called once per frame
    void Update()
    {
        projectileSpawnRate -= Time.deltaTime;

        if (projectileSpawnRate <= 0 )
        {
            startPoint = transform.position;
            SpawnProjectile(numberOfProjectiles);
            projectileSpawnRate = projectileSpawnStartRate;
        }
    }

    private void SpawnProjectile(int projectileNumber)
    {
        float angleStep = 360 / projectileNumber;
        float angle = 0f;

        for (int i = 0; i <= projectileNumber; i++)
        {
            float projectileDirXPosition =
                startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPosition =
                startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector3 projectileVector = new Vector3(
                projectileDirXPosition,
                projectileDirYPosition,
                0
            );
            Vector3 projectileMoveDirection =
                (projectileVector - startPoint).normalized * projectileSpeed;

            GameObject tmpObj = Instantiate(ProjectilePrefab, startPoint, Quaternion.identity);
            tmpObj.GetComponent<Rigidbody>().velocity = new Vector3(
                projectileMoveDirection.x,
                0,
                projectileMoveDirection.y
            );
            angle += angleStep;
        }
    }
}
