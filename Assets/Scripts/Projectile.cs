using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float chargeTime = 1.5f;
    private float counter;
    bool isCharging = false;

    void Start()
    {
        source = gameObject.GetComponent();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            isCharging = true;
            source.Play("Cue_Charging");
            counter = Time.time;
        }


        if (Input.GetKeyUp("space") || (Time.time - counter) > chargeTime)
            if (isCharging)
            {
                isCharging = false;
                float chargeAmount = Time.time - counter;

            }
    }
}