using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedModule : MonoBehaviour
{
    // Start is called before the first frame update
     Movement movement;
    public float increaseSpeed = 2;
    //for Addtional type
    public static GameObject Samemodule;
    
    void Start()
    {
        
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        movement.PlayerSpeed += increaseSpeed;
        if(Samemodule)
        {
            Samemodule.transform.localScale  *= 0.25f;
            Destroy(this);
        }else
        {
            Samemodule = this.gameObject;
        }
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
