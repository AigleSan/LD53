using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralBulletController : MonoBehaviour
{
    public int numberOfProjectiles;
    public float projectileSpeed;

    private float projectileSpawnRate;

    public float projectileSpawnStartRate;
    public GameObject ProjectilePrefab;

    private Vector3 startPoint;

    public float bulletDrift;

    private const float radius = 1f;

    // Start is called before the first frame update
    void Start()
    {
        projectileSpawnRate = projectileSpawnStartRate;
    }

    // Update is called once per frame
    void Update()
    {
        projectileSpawnRate -= Time.deltaTime;

        if (projectileSpawnRate <= 0)
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
                startPoint.x + Mathf.Sin((angle + 180f * i) * Mathf.PI) / 180f;
            float projectileDirYPosition =
                startPoint.y + Mathf.Cos((angle + 180f * i) * Mathf.PI) / 180f;

            Vector3 projectileVector = new Vector3(
                projectileDirXPosition,
                projectileDirYPosition,
                0
            );
            Vector3 projectileMoveDirection =
                (projectileVector - startPoint).normalized * projectileSpeed;

            GameObject tmpObj = Instantiate(ProjectilePrefab, startPoint, Quaternion.identity);
            tmpObj.GetComponent<Rigidbody>().velocity =
                new Vector3(projectileMoveDirection.x, 0, projectileMoveDirection.y);
            angle += angleStep;

            if(angle >=360f){
                angle = 0f;
            }

            //tmpObj.transform.rotation = Quaternion.Euler(0, bulletDrift, 0);
        }
    }
}
