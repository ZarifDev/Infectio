using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastReloadModule : MonoBehaviour
{
     Player playerScript;
    public float reloadSpeedIncrease = 2;
    
    void Start()
    {
        
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerScript.velocidadeDeRecarga = reloadSpeedIncrease;

 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
