using UnityEngine;

public class InimigoBase : MonoBehaviour
{
    public float vidaAtual = 3;
    public float vidaMaxima = 3;
    public int custoParaSerSpawnado = 1;
    public GameObject vidaPrefab; // refer. ao ao prefab do item de vida
    Player playerScript;
    public static bool chanceDeDroparVida = false;

    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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
        if (DeveDroparVida())
        {
            chanceDeDroparVida = true;
            Instantiate(vidaPrefab, transform.position, Quaternion.identity); // instancia o item de vida na posi��o do inimigo
        }
        LevelSpawner.enemiesActiveInScene.Remove(gameObject);
        Destroy(gameObject);
    }

    bool DeveDroparVida()
    {
        float chance = 10f;
        float sorteio = Random.Range(0f, 100f);
        return sorteio <= chance;
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "PlayerBullet")
        {
            TomarDano(PlayerBullet.damage);
            Destroy(other.gameObject);
        }
    }
   
}















