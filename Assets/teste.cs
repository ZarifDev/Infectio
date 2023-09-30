using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidade;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x -1*velocidade,1,1);
        print("h");
    }
     void FixedUpdate() 
    {
        
    }
    
}
