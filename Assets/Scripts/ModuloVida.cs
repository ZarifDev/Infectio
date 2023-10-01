using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuloVida : MonoBehaviour
{
    public float speed = 5.0f;
    public int lifeRegen;

    public Player playerScript;
    // Start is called before the first frame update

    void Start()
    {
        playerScript.vidaAtual = playerScript.vidaAtual + lifeRegen;
    }

    // Update is called once per frame
    /*
    void Update()
    {
      
    }


    private void OnTriggerEnter(Collider other) //
    {
        GanharVida(other); //
    }


    public void GanharVida(Collider other) // metodos nao tem necessidade de ser minuscula;; gaveta
    {
        if (other.CompareTag("Player")) // se o obj colidido estiver com a tag "Player".
        {
            Destroy(this.gameObject);  // o que acontece se a tag "Player"
        }
    }
    */
}
