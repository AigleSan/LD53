using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    // Start is called before the first frame update

    int damage;
    float travelTime;
    public float throwForce;

    Rigidbody rb;

    Transform player;


    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);

        if (Input.GetKeyDown(KeyCode.Y) && dist <= 0.1f)
        {
            Throw();
        }
    }

    private void Throw()
    {
        rb.AddForce(player.forward * throwForce, ForceMode.VelocityChange);
    }
}
