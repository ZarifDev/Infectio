
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeItem : MonoBehaviour
{
    public float speed = 5.0f;
    public int lifeRegen;

    Player playerScript;

    // Start is called before the first frame update

    void Start()
    {
        Destroy(gameObject,10);
        //quando a vida for spawnada ela vai procurar na cena se tem um objeto chamado player e pegar o script player dele
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moviment = new Vector3(-1, 0, 0) * speed * Time.deltaTime;    // X, Y, Z o deltaTime FRAME
        transform.Translate(moviment);
    }


    private void OnTriggerEnter(Collider other) //
    {
        EarnLife(other); //
    }


    public void EarnLife(Collider other) // metodos nao tem necessidade de ser minuscula;; gaveta
    {
        if (other.CompareTag("Player")) // se o obj colidido estiver com a tag "Player".
        {
            //cura o player acessando o script player e aumenta a vida atual e depois se destroi
            playerScript.Cura(lifeRegen);
            print("cura");
            Destroy(this.gameObject);  // o que acontece se a tag "Player"?
        }
    }
}