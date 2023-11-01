using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeModule : MonoBehaviour
{
    Transform playerTransform;
    public float playerSize = 0.75f;

   // Start is called before the first frame update

    void Start()
    {
      transform.localScale *= playerSize;
       playerTransform =  GameObject.FindGameObjectWithTag("Player").transform;
         playerTransform.localScale *= playerSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}