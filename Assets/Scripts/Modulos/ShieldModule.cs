using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldModule : MonoBehaviour
{
    public float shieldStrength = 100f; // a quantidade de dano que o escudo pode absorver
    public float currentShield; // A quantidade atual de escudo
    private Player playerScript; // refer�ncia ao script do jogador "Player"?

    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
       RestoreShield(); // deixar em 100%?
    }

    public void TakeDamage(float damage)
    {
        if (currentShield > 0) // escudo restante
        {
          
            currentShield -= damage; // reduz a for�a do escudo pelo dano absorvido
           
        }
        else if (playerScript != null)
        {
            playerScript.TakeDamage(damage);
        }
      
    }
    public void RestoreShield()
    {
        currentShield = shieldStrength;
    }

}