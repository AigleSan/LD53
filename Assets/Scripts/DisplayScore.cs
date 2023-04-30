using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayScore : MonoBehaviour
{
public TMP_Text scoreText;
    public GameObject player;
    public PlayerDelivery playerDelivery;
    public int displayScore;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerDelivery = player.GetComponent<PlayerDelivery>();
        
        scoreText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        displayScore = playerDelivery.newspaperCount;
        scoreText.text = displayScore.ToString();
    }
}
