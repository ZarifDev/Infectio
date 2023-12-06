using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeModule : MonoBehaviour
{
    Transform playerTransform;
    public float playerSize = 0.75f;
    public float bulletLifeTimeDecrease = 0.3f;
    float currentBulletLifeTime = -1;

   // Start is called before the first frame update

    private void OnEnable() {

      transform.localScale *= playerSize;
       playerTransform = Player.instance.transform;
         playerTransform.localScale *= playerSize;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerBullet.lifeTime >=0.7f && PlayerBullet.lifeTime !=  currentBulletLifeTime)
        {
          PlayerBullet.lifeTime -= bulletLifeTimeDecrease;
          currentBulletLifeTime =  PlayerBullet.lifeTime;
        }
    }
    private void OnDestroy() {
    playerTransform.localScale = Vector3.one;
    }

}