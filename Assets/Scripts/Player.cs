using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float vidaMaxima = 3; 
    public float vidaAtual = 3;


    public Slider Slider;
    public GameObject cubo;
    public BoxCollider colisor;



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
    private void OnCollisionEnter(Collision algum_objeto) 
    {
        if(algum_objeto.gameObject.tag == "Inimigo")
        {
            vidaAtual = vidaAtual -1;
            
        }
        }
    }
    
