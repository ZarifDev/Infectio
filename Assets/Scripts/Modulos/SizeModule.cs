using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeModule : MonoBehaviour
{
    public Transform playerTransform;
    public float playerSize;

   // Start is called before the first frame update

    void Start()
    {
       playerTransform =  GameObject.FindGameObjectWithTag("Player").transform;
         playerTransform.localScale *= playerSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}