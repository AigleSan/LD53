using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{[SerializeField]
    private Rigidbody rb;
    [SerializeField] private float movementSpeed;
    //[SerializeField] private Animator anim;

    private bool isMoving;


    Vector3 forward, right;
    public Vector3 heading;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        //anim = GetComponentInChildren(typeof(Animator)) as Animator;

    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {

            Move();
            isMoving = true;

        }
        else
        {
            isMoving = false;
        }

    }


    void Move()
    {

        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 rightMovement = right * movementSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * movementSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        heading = Vector3.Normalize(rightMovement + upMovement);
        Vector3 movement = Vector3.Normalize(heading) * movementSpeed * Time.deltaTime;
        //transform.forward = heading;
        transform.position += movement;

    }

}
