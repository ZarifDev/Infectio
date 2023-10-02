using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastReloadModule : MonoBehaviour
{
    Player playerScript;
    public float reloadSpeedIncrease = 2;
    float defaultReloadSpeed;
    void Start()
    {
        
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

 
    }

    // Update is called once per frame
    void Update()
    {
        
       playerScript.velocidadeDeRecargaAtual =  playerScript.velocidadeDeRecargaDaArma + reloadSpeedIncrease;
    }
}
