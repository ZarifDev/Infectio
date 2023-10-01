using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuloVida : MonoBehaviour
{
    public float speed = 5.0f;
    public int lifeRegen;


    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moviment = new Vector3(-1, 0, 0) * speed * Time.deltaTime;    // X, Y, Z o deltaTime FRAME
        transform.Translate(moviment);
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
}
