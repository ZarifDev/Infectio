using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuloVida : MonoBehaviour
{
    public float speed = 5.0f;
    public int maxlifeIcrease;
    public Player playerScript;
    // Start is called before the first frame update

    void Start()
    {

        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerScript.vidaMaxima = maxlifeIcrease;
        playerScript.Cura(playerScript.vidaMaxima);
    }

}