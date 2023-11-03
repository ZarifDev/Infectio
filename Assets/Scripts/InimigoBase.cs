using UnityEngine;

public class InimigoBase : MonoBehaviour
{
    public float vidaAtual = 3;
    public float vidaMaxima = 3;
    public int custoParaSerSpawnado = 1;
    public AudioClip deathSound;
    public GameObject vidaPrefab; // refer. ao ao prefab do item de vida
    Player playerScript;
    public static bool chanceDeDroparVida = false;


    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        vidaAtual = vidaMaxima;
     print(chanceDeDroparVida);
        
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
        playerScript.PlaySound(deathSound);
        if (DeveDroparVida() && chanceDeDroparVida)
        {
            
            Instantiate(vidaPrefab, transform.position, Quaternion.identity); // instancia o item de vida na posi��o do inimigo
        }
        LevelSpawner.enemiesActiveInScene.Remove(gameObject);
        Destroy(gameObject);
    }

    bool DeveDroparVida()
    {
        float chance = 10f;
        float sorteio = Random.Range(0f, 100f);
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
            TomarDano(PlayerBullet.damage);
            Destroy(other.gameObject);
        }
    }
   
}















