using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVida : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5.0f;
    public int lifeRegen;

    public Player playerScript;
    // Start is called before the first frame update

    void Start()
    {

        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerScript.Cura(lifeRegen);
    }

}

