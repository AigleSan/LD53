using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public float timer;

    public bool timerIsRunning;

    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                //timerIsRunning = true;
            }
            else
            {
                Debug.Log("Fin de la partie");
                timer = 0;
                timerIsRunning = false;
            }
        }

        if (timer <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void addTime(float time)
    {
        timer += time;
    }
}
