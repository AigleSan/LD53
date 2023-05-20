using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update

    private int currHealth;
    public int maxHealth;

    EnemyHealthbar enemyHealthbar;

    void Start()
    {
        currHealth = maxHealth;
        enemyHealthbar = GetComponentInChildren<EnemyHealthbar>();
        enemyHealthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int health)
    {
        currHealth -= health;
    }

    private void OnCollisionEnter(Collision other)
    {
        // if(other.gameObject.tag == "EnemyBullet"){

        //     Physics.IgnoreCollision(other.collider, this.gameObject.GetComponent<Collider>());
        // }
    }

    public int getCurrentHealth()
    {
        return currHealth;
    }
}
