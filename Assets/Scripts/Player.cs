using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float vidaMaxima = 3; 
    public float vidaAtual = 3;

    public float velocidadeDeRecargaDaArma;
    public float velocidadeDeRecargaAtual;

    public Slider Slider;
    public GameObject cubo;
    public BoxCollider colisor;
    public static bool playerCantDoNothing;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Slider.value = vidaAtual;
    }
    
    public void Cura(float vidaParaCurar)
    {
        //aumenta  a vida atual do player quandoa vida dele estive menor que avida maxima
        if(vidaAtual + vidaParaCurar > vidaMaxima){
        vidaAtual = vidaMaxima;
        }
    }
    public void  TakeDamage(float QuantidadeDeDano)
    {
        if(vidaAtual - QuantidadeDeDano >=0){
        vidaAtual -= QuantidadeDeDano;
        }else
        {
            vidaAtual = 0;
        }
    }
    private void OnCollisionEnter(Collision algum_objeto) 
    {
        if(algum_objeto.gameObject.tag == "Inimigo")
        {
            vidaAtual = vidaAtual -1;
            
        }
    
        }
    }
    
