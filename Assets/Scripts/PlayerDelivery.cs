using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerDelivery : MonoBehaviour
{
    public int newspaperCount,
        maxNewspaperCount;

    public float deliveryStartCooldown;

    public float timeAddedByNewspaper = 15;

    [SerializeField]
    private float deliveryCooldown;

    // Start is called before the first frame update


    public GameObject gameManager;

    public GameManager gameManagerScript;

    public int deliveryPoints;

    void Start()
    {
        deliveryCooldown = deliveryStartCooldown;
        deliveryPoints = GameObject.FindGameObjectsWithTag("DeliveryPoint").Length;
        Debug.Log(deliveryPoints);
    }

    // Update is called once per frame
    void Update()
    {
        deliveryCooldown -= Time.deltaTime;
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();

        if (deliveryPoints == 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Newspaper" && (newspaperCount < maxNewspaperCount))
        {
            newspaperCount++;
            gameManagerScript.addTime(timeAddedByNewspaper);
            Destroy(other.gameObject);
            Debug.Log(newspaperCount + " journaux ramassés !");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (newspaperCount > 0)
        {
            if (
                Input.GetKey(KeyCode.Space)
                && (other.gameObject.tag == "DeliveryPoint")
                && (deliveryCooldown <= 0)
            )
            {
                newspaperCount--;
                deliveryPoints--;
                deliveryCooldown = deliveryStartCooldown;
                Debug.Log("Journal Livré ! Il en reste " + newspaperCount);
                Debug.Log("Il reste encore " + deliveryPoints + " à livrer !");
                Destroy(other.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Mob")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
