using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedModule : MonoBehaviour
{
    // Start is called before the first frame update
     Movement movement;
    public float increaseSpeed = 2;
    
    void Start()
    {
        
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        movement.PlayerSpeed += increaseSpeed;

 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
