using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeliveryScore : MonoBehaviour
{
    public GameObject player;
    public PlayerDelivery playerDelivery;

    public TMP_Text deliveryScoreText;

    public int displayScore;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerDelivery = player.GetComponent<PlayerDelivery>();
        displayScore = playerDelivery.deliveryPoints;
    }

    // Update is called once per frame
    void Update()
    {
        displayScore = playerDelivery.deliveryPoints;
        deliveryScoreText.text = displayScore.ToString();
    }
}
