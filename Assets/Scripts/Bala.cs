using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 6;
    public float lifeTime = 2;

    void Start()
    {
        Destroy(gameObject,lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 movement = new Vector3(-1, 0, 0) * speed * Time.deltaTime; 
        transform.Translate(movement);
    }
}
