using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private int damage;

    [SerializeField]
    private float lifespan;

    //public PlayerRotation playerRotation;

    void Start()
    {
        //playerRotation = GameObject.Find("Player").GetComponent<PlayerRotation>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, lifespan);
    }

    private void OnTriggerEnter(Collider other)
    {
        // if(other.gameObject.tag == "Enemy"){
        //     //Damage Enemy yeah yeah
        //     other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        //     Debug.Log(other.gameObject.name + " a pris " + damage + " dégats");
        //     Destroy(this.gameObject);
        // }

        // if(other.gameObject.tag == "Mob"){

        //     Destroy(other.gameObject);
        // }

        //Destroy(this.gameObject);
        if (other.gameObject.tag == "EnemyBullet")
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            other.gameObject
                .GetComponentInChildren<EnemyHealthbar>()
                .SetHealth(other.gameObject.GetComponent<EnemyHealth>().getCurrentHealth());
            Destroy(this.gameObject);
            Debug.Log(other.gameObject.name + " a reçu" + damage + " degats");
        }
    }
}
