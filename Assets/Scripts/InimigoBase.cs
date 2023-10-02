using UnityEngine;

public class InimigoBase : MonoBehaviour
{
    public float vidaAtual;
    public float vidaMaxima;
    public GameObject vidaPrefab; // refer. ao ao prefab do item de vida

    Player playerScript;
    public static bool chanceDeDroparVida = false;

    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void TomarDano(float QuantidadeDeDano)
    {
        if (vidaAtual - QuantidadeDeDano >= 0)
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
        Destroy(gameObject);
    }

    bool DeveDroparVida()
    {
        float chance = 10f;
        float sorteio = Random.Range(0f, 100f);
        return sorteio <= chance;
    }
}















