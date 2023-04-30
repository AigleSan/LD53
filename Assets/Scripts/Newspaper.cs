using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaper : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float lifespan;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     lifespan -= Time.deltaTime;   

     if (lifespan <= 0){
        Destroy(this.gameObject);
     }
    }
}
