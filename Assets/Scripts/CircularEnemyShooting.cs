using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularEnemyShooting : MonoBehaviour
{
    public int circularAngleIncrease = 10;
    public float circularShootFireRate = 1;
    public float bigShootFireRate = 1;
    float variationShotAngle;
    public GameObject bullet;
    Transform player;
    public float fireRate;
    float currentFireTime;
    public bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
         player = Player.instance.transform;
       currentFireTime = Random.Range(0,fireRate);
    }

    // Update is called once per frame
    void Update()
    {
    Atirar();
   
    }
   

    private void Atirar()
    {
    currentFireTime -= Time.deltaTime;

    if (currentFireTime <= 0)
    {
        for (int angle = -180; angle < 180; angle += circularAngleIncrease)
        {
        Instantiate(bullet,transform.position,Quaternion.Euler(0,0,angle +variationShotAngle));
        currentFireTime = fireRate;
        }
            if(variationShotAngle !=0)
            {
                variationShotAngle =0;
            }else
            {
        variationShotAngle = circularAngleIncrease/2;
            }
    }
    }
}
