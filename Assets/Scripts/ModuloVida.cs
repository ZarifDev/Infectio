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
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerScript.vidaAtual = playerScript.vidaAtual + lifeRegen;
    }

}