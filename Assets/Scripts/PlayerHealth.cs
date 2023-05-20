using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public int maxHealth;
    public PlayerHealthBar Healthbar;


    private int currHealth;
    void Start()
    {
        currHealth = maxHealth;
        Healthbar = GameObject.Find("PlayerHealthBar").GetComponent<PlayerHealthBar>();
        Healthbar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){

            TakeDamage(5);
        }
    }

    public void TakeDamage(int damage){

        currHealth -= damage;
        Debug.Log("Vous avez reçu" + damage);
        Healthbar.SetHealth(currHealth);

    }
}
