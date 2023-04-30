using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerDisplay : MonoBehaviour
{

    public GameObject gameManager;
    public GameManager gameManagerScript;

    public TMP_Text timerDisplay;

    public float timerValue;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();

        timerValue = gameManagerScript.timer;
    }

    // Update is called once per frame
    void Update()
    {
        timerValue = gameManagerScript.timer;
        DisplayTime(timerValue);
    }

    void DisplayTime(float timeToDsiplay){
        float minutes = Mathf.FloorToInt(timeToDsiplay /60);
        float seconds = Mathf.FloorToInt(timeToDsiplay %60);
        timerDisplay.text = string.Format("{0:0 0} {1:0 0}", minutes, seconds);


    }
}
