using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool canJump;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    //private float jumpForce;

    public Rigidbody rb;
    public Animator anim;
    public SpriteRenderer graphics;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        graphics = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var movementX = Input.GetAxisRaw("Horizontal");
        var movementZ = Input.GetAxisRaw("Vertical");
        transform.position +=
            new Vector3(movementX, 0f, movementZ).normalized * moveSpeed * Time.deltaTime;

        Vector3 direction = new Vector3(movementX, 0f, movementZ).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
        }

        // if (canJump == true && Input.GetKeyDown(KeyCode.Space))
        // {
        //     rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //
        // }
        if (movementZ >= 0.1f)
        {
            anim.Play("backWalk");
        }
        else if (movementZ <= -0.1f)
        {
            anim.Play("frontWalk");
        }

        else if (movementX >= 0.1f && movementZ == 0)
        {
            anim.Play("sideWalk");
        }

        else if (movementX <= -0.1f && movementZ == 0)
        {
            anim.Play("sideWalkLeft");
            //graphics.flipY;
        }

        else{
            anim.Play("idle");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            canJump = true;
            Debug.Log("on ground");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            canJump = false;
            Debug.Log("on ground");
        }
    }
}
