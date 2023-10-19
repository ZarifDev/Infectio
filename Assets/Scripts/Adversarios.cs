using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adversarios : MonoBehaviour
{
    public GameObject Tiro;
    public Transform Arma;
    public Transform[] localDoDisparo;
    public float velocidadedoadversario;
    public float tempoMaximoEntreOsTiros;
    float tempoAtualEntreOsTiros;
    public bool atirarNoJogador;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
       tempoAtualEntreOsTiros = Random.Range(0,tempoMaximoEntreOsTiros);
    }

    // Update is called once per frame
    void Update()
    {
       
        Atirar();
         if(atirarNoJogador)
        {
      Arma.transform.rotation = Quaternion.FromToRotation(Vector3.left,  player.transform.position - transform.position);
        }
    }
   

    private void Atirar()
    {
        tempoAtualEntreOsTiros -= Time.deltaTime;

        if (tempoAtualEntreOsTiros <= 0)
        {
            for (int i = 0; i < localDoDisparo.Length; i++)
            {
       
            Instantiate(Tiro, localDoDisparo[i].position, localDoDisparo[i].rotation );
            tempoAtualEntreOsTiros = tempoMaximoEntreOsTiros;

            }

        }
        
    }
}
