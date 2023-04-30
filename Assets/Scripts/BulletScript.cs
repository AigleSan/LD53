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

    void Start() { }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, lifespan);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Enemy"){
            //Damage Enemy yeah yeah
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            Debug.Log(other.gameObject.name + " a pris " + damage + " dégats");
            Destroy(this.gameObject);
        }

        if(other.gameObject.tag == "Mob"){

            Destroy(other.gameObject);
        }

        //Destroy(this.gameObject);
     }
}
