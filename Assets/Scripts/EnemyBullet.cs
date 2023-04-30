using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private int damage;

    [SerializeField] private float lifespan;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, lifespan);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){

            //Infliger des dégats
        }
    }

    // private void OnCollisionEnter(Collision other) {
    //     if(other.gameObject.tag == "Enemy"){
    //         Physics.IgnoreCollision(other.collider, this.gameObject.GetComponent<SphCollider>());
    //     }
    // }

    
}
