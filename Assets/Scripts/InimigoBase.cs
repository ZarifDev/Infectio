using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoBase : MonoBehaviour
{
    // Start is called before the first frame update

    public float vidaAtual;
    public float vidaMaxima;
    Player playerScript;
    public static bool chanceDeDroparVida = false;
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
   public void  TomarDano(float QuantidadeDeDano)
    {
        if(vidaAtual - QuantidadeDeDano >=0){
        vidaAtual -= QuantidadeDeDano;
        }else
        {
            vidaAtual = 0;
            morrer();
        }
    }
    public void morrer()
    {
        Destroy(gameObject);
    }
}














