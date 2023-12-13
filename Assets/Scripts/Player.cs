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
     public ParticleSystem hitFlash;
    public static Player instance;
    public ParticleSystem muzzleFlash;
    ModuleMananger moduleMananger;
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
        if(!moduleMananger)
        {
          moduleMananger = GetComponent<ModuleMananger>();
        }
    }
    void Start()
    {
      InitialUpgrade();
      vidaAtual = vidaMaxima;

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
          lifeSlider.value = vidaAtual;
        lifeSlider.maxValue = vidaMaxima;
             PlaySound(playerHeal);
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
         hitParticle(algum_objeto.contacts[0].point);
        TakeDamage(1);
     
      }
    }
        void hitParticle(Vector3 pos)
        {
          if(!isInvencible ){
           hitFlash.transform.position = pos;
            hitFlash.Play();
        }
        }
        void OnTriggerEnter(Collider other)
        {
          if(other.gameObject.tag == "Bala")
          {
              hitParticle(other.ClosestPoint(transform.position));
            TakeDamage(1);
            Destroy(other.gameObject);
          
          }
          
          if(other.gameObject.tag == "BossBullet")
          {
             hitParticle(other.ClosestPoint(transform.position));
            TakeDamage(2);
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
    void InitialUpgrade()
    {
      if(GameData.instance.InitialItem.itemObject != null){
        print("initialUpgrade");
         Instantiate(GameData.instance.InitialItem.itemObject,transform.position,GameData.instance.InitialItem.itemObject.transform.rotation);
      }
    }
   
}
    
