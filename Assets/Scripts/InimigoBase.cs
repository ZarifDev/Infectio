using UnityEngine;

public class InimigoBase : MonoBehaviour
{
    public float vidaAtual = 3;
    public float vidaMaxima = 3;
    public bool contactDestroy= false;
    public int custoParaSerSpawnado = 1;
    public AudioClip deathSound;
    public AudioClip hitSound;
    public GameObject vidaPrefab; // refer. ao ao prefab do item de vida
    public static bool chanceDeDroparVida = false;
    public ParticleSystem hitFlash;
    public GameObject blood;

    void Start()
    {
   
        vidaAtual = vidaMaxima;

        
    }

    public void TomarDano(float QuantidadeDeDano)
    {
        if (vidaAtual - QuantidadeDeDano > 0)
        {
            vidaAtual -= QuantidadeDeDano;
          
        }
        else
        {
            vidaAtual = 0;
            morrer();
        }
        
    }

    public void morrer()
    {
        Player.instance.PlaySound(deathSound);
            Instantiate(blood,transform.position,Quaternion.identity);
        if (DeveDroparVida() && chanceDeDroparVida)
        {
            
            Instantiate(vidaPrefab, transform.position, Quaternion.identity); // instancia o item de vida na posi��o do inimigo
        }
        LevelSpawner.enemiesActiveInScene.Remove(gameObject);
         if(LevelSpawner.enemiesActiveInScene.Count <1){
            Score.instance.AddScore(1500);
            }
    
        Destroy(gameObject);
    }

    bool DeveDroparVida()
    {
        int chance = 10;
        int sorteio = Random.Range(0, 100);
        if(sorteio <= chance)
        {
            return true;
        }else
        {
             return false;
        }
    }
    private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.tag == "PlayerBullet")
        {
             Player.instance.PlaySound(hitSound);
            TomarDano(PlayerBullet.damage);
            hitFlash.transform.position = other.ClosestPoint(transform.position);
            hitFlash.Play();
            Destroy(other.gameObject);
          
        }
        if(other.gameObject.tag == "Player"&&contactDestroy)
        {
           
         Player.instance.TakeDamage(1);
                morrer();
            
        }
    }
    
}















