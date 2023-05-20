using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerShootScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static Action shootInput;
    public static Action reloadInput;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            shootInput?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.R)){
            reloadInput?.Invoke();

        }
    }
}
