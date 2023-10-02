using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adversarios : MonoBehaviour
{
    public GameObject Tiro;
    public Transform[] localDoDisparo;
    public float velocidadedoadversario;

    public float tempoMaximoEntreOsTiros;
    public float tempoAtualEntreOsTiros;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        Atirar();
    }
   

    private void Atirar()
    {
        tempoAtualEntreOsTiros -= Time.deltaTime;

        if (tempoAtualEntreOsTiros <= 0)
        {
            for (int i = 0; i < localDoDisparo.Length; i++)
            {
                
            Instantiate(Tiro, localDoDisparo[i].position, localDoDisparo[i].rotation);
            tempoAtualEntreOsTiros = tempoMaximoEntreOsTiros;

            }

        }
        else
        {
            tempoAtualEntreOsTiros -= 1;
        }
    }
}
