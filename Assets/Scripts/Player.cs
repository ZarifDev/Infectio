using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float vidaMaxima = 3; 
    public float vidaAtual = 3;

    public float velocidadeDeRecargaDaArma;
    public float velocidadeDeRecargaAtual;
    public Slider Slider;
    public static bool playerCantDoNothing;
  


    void Start()
    {
      vidaAtual = vidaMaxima;
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Escape))
      {
        SceneManager.LoadScene(0);
      }
    }
    
    public void Cura(float vidaParaCurar)
    {
        //aumenta  a vida atual do player quandoa vida dele estive menor que avida maxima
        if(vidaAtual + vidaParaCurar > vidaMaxima){
        vidaAtual = vidaMaxima;
        }else
        {
             vidaAtual += vidaParaCurar;
        }
          Slider.value = vidaAtual;
    }
    public void  TakeDamage(float QuantidadeDeDano)
    {
        if(vidaAtual - QuantidadeDeDano >=0){
        vidaAtual -= QuantidadeDeDano;
        }else
        {
            vidaAtual = 0;
        }
          Slider.value = vidaAtual;
    }
    void OnCollisionEnter(Collision algum_objeto) 
    {
      
      if(algum_objeto.gameObject.tag == "Inimigo")
      {
        TakeDamage(1);
         algum_objeto.gameObject.GetComponent<InimigoBase>().TomarDano(10000);
      }
    }
        
        void OnTriggerEnter(Collider other)
        {
   
        if(other.gameObject.tag == "Bala")
        {
           TakeDamage(1);
           Destroy(other.gameObject);
            
        }
        }
    }

    
