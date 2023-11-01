using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastReloadModule : MonoBehaviour
{
    Player playerScript;
    public float reloadSpeedIncrease = 1;
    float defaultReloadSpeed;
    void Start()
    {
        
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerScript.velocidadeDeRecargaAtual =  playerScript.velocidadeDeRecargaDaArma - reloadSpeedIncrease;
 
    }

    // Update is called once per frame
    void Update()
    {
        
      
    }
}
