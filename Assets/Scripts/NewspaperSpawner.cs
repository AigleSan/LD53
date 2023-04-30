using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject newspaper;

    [SerializeField]
    private int coeff;

    private float newspaperSpawnCooldown;
    public float newspaperStartCooldown;

    void Start()
    {
        GenerateNewspaper();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - newspaperSpawnCooldown >= newspaperStartCooldown) { 
            coeff++;
            GenerateNewspaper();
        }
    }

    private void GenerateNewspaper()
    {
        newspaperSpawnCooldown = Time.time;
        GameObject newNewspaper = Instantiate(newspaper);
        newNewspaper.transform.position = new Vector3(
            Random.Range(0f, 80f),
            (2f),
            Random.Range(0f, 40f)
        );
    }
}
