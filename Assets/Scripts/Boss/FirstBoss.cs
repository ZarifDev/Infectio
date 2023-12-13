using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstBoss : MonoBehaviour
{
  public int maxLife = 50;
  public float currentLife = 50f;
  public Slider lifeSlider;
  public int circularAngleIncrease = 5;
  public float circularShootFireRate = 1;
  public float bigShootFireRate = 1;
  float variationShotAngle;
  public float speed;
   public float screenCenterOffsetX = 10f;
  public Transform firepoint;
  public GameObject BulletAttackPattern1;
  public GameObject BulletAttackPattern2;
  public GameObject BulletAttackPattern3;
  public ParticleSystem hitFlash;
   public GameObject blood;
  Transform player;
  bool canStartAttacking;
  public AudioClip epicSound;
  public AudioClip nextLevel;
  void Start()
  {
    currentLife = maxLife;
    lifeSlider.gameObject.SetActive(true);
    lifeSlider.maxValue = maxLife;
    lifeSlider.value = maxLife;
    player = GameObject.FindGameObjectWithTag("Player").transform;
    Player.instance.PlaySound(epicSound);
  
  }
  void Update()
  {
     if(transform.position.x >= screenCenterOffsetX ){
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        }else if(!canStartAttacking)
        {
          InvokeRepeating("CircularShootAttack",0,circularShootFireRate);
          canStartAttacking = true;
        }
     
  }
  void CircularShootAttack()
  {
    for (int angle = -90; angle < 90; angle += circularAngleIncrease)
    {
      Instantiate(BulletAttackPattern1,firepoint.position,Quaternion.Euler(0,0,angle +variationShotAngle));
    }
    if(variationShotAngle !=0)
    {
        variationShotAngle =0;
    }else
    {
  variationShotAngle = circularAngleIncrease/2;
    }

    if(currentLife > maxLife/2){
    return;
    }else
    {
      CancelInvoke("CircularShootAttack");
      InvokeRepeating("BigShoot",3,bigShootFireRate);
    }
  }
  void BigShoot()
  {
      Instantiate(BulletAttackPattern2,transform.position,Quaternion.FromToRotation(Vector3.left,  player.transform.position - transform.position));
  
  }
  public void TakeDamage(float damage)
    {
        if (currentLife - damage > 0)
        {
            currentLife -= damage;
        }
        else
        {
            currentLife = 0;
           Die();
        }
    lifeSlider.value = currentLife;
}
  private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "PlayerBullet")
        {
            hitFlash.transform.position = other.ClosestPoint(other.transform.position);
            hitFlash.Play();
            TakeDamage(PlayerBullet.damage);
            Destroy(other.gameObject);
        }
    }
    void Die()
    {
       Player.instance.PlaySound(nextLevel);
       lifeSlider.gameObject.SetActive(false);
      Destroy(this.gameObject);
      Instantiate(blood,transform.position,Quaternion.identity);
    }
    
}
