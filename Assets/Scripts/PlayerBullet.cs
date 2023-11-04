using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBullet : MonoBehaviour
{
  
    [SerializeField] float speed = 5;
    [SerializeField] float lifeTimeDelay = 0.2f;
    public static float lifeTime= 3;
    public static float damage = 1;
     public static float speedIncrease;
    


    // Update is called once per frame
    void Start()
    {
        Invoke("StopBullet",lifeTime-lifeTimeDelay);
        Destroy(this.gameObject,lifeTime);
    }
    void Update()
    {   
         transform.Translate(Vector3.right * Time.deltaTime*(speed+speedIncrease)); 
         
    }
    void StopBullet()
    {
        speed /= 4;
    }
}
