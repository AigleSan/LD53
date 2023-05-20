using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
       [SerializeField] private float dashForce;
    [SerializeField] private float dashDuration;
    //[SerializeField] private Animator anim;
    private float cooldown = 0f;
    public float startCooldown = 3f;

    public PlayerMovement playerMovement;


    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //anim = GetComponentInChildren(typeof(Animator)) as Animator;
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && cooldown <= 0)
        {
            StartCoroutine(Dash());
            //anim.Play("aa_dash");

            cooldown = startCooldown;
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }

    IEnumerator Dash()
    {
        
        rb.AddForce(playerMovement.heading * dashForce, ForceMode.Impulse); //VelocityChange  et Impulse à tester
        yield return new WaitForSeconds(dashDuration);
        rb.velocity = Vector3.zero;
    }
}
