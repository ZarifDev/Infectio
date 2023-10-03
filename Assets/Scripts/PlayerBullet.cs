using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
  
    [SerializeField] float speed;
    public float lifeTime= 3;
    public static float damage = 1;

    // Update is called once per frame
    void Start()
    {
        Destroy(gameObject,lifeTime);
    }
    void Update()
    {
         transform.Translate(Vector3.right * Time.deltaTime*speed); 
    }
}
