using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
   public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0,0,Random.Range(0,360f));
    }

    // Update is called once per frame
    void Update()
    {
         transform.Rotate (0,0,rotationSpeed*Time.deltaTime);
    }
}
