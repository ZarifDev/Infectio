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
    public float invencibleTime = 1;
    public float velocidadeDeRecargaDaArma;
    public float velocidadeDeRecargaAtual;
    public Slider lifeSlider;
    public Slider reloadSlider;
    public static bool playerCantDoNothing;
    public static AudioSource audioSource;
    bool isInvencible;
    public AudioClip playerHit;
    public AudioClip playerHeal;
    public static Player instance;

     private void Awake() 
    {
      if(instance != null && instance != this)
      {
        Destroy(this.gameObject);
      }else
      {
       instance =this;
      
      }
  
      Time.timeScale = 1;
      print("started");
      vidaAtual = vidaMaxima;

     
    }
   

    // Update is called once per frame
    void Update()
    {
      if(!audioSource)
      {
          audioSource = GetComponent<AudioSource>();
      }
       if(Input.GetKeyDown(KeyCode.V))
      {
       vidaMaxima =99999;
       vidaAtual =vidaMaxima;
      }
       lifeSlider.value = vidaAtual;
        lifeSlider.maxValue = vidaMaxima;
        if(!lifeSlider)
        {
              lifeSlider = GameObject.Find("PlayerLife").GetComponent<Slider>();
              reloadSlider = GameObject.Find("ReloadSlider").GetComponent<Slider>();
        }
    }
    
    public void Cura(float vidaParaCurar)
    {
        //aumenta  a vida atual do player quandoa vida dele estive menor que avida maxima
        PlaySound(playerHeal);
        if(vidaAtual + vidaParaCurar > vidaMaxima){
        vidaAtual = vidaMaxima;
        }else
        {
             vidaAtual += vidaParaCurar;
        }
         
    }
    public void  TakeDamage(float QuantidadeDeDano)
    {
      if(!isInvencible){
        if(vidaAtual - QuantidadeDeDano >0){
        vidaAtual -= QuantidadeDeDano;
        }else
        {
            vidaAtual = 0;
            Die();
        
        }
          lifeSlider.value = vidaAtual;
          isInvencible = true;
          Invoke("ExitInvecibleMode",invencibleTime);
          PlaySound(playerHit);
      }
    }
    void ExitInvecibleMode()
    {
     isInvencible = false;
    }
     private void OnCollisionStay(Collision algum_objeto) 
    {
      
      if(algum_objeto.gameObject.tag == "Inimigo" && !isInvencible)
      {
        TakeDamage(1);
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
    
    public void PlaySound(AudioClip clip)
    {
      audioSource.PlayOneShot(clip);
    }
    void Die()
    {
      GameMananger.instance.GameOver();
    }
   
}
    
