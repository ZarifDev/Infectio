using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adversarios : MonoBehaviour
{
    public GameObject Tiro;
    public Transform localDoDisparo;
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
        MovimentarAdversario();
        Atirar();
    }
    private void MovimentarAdversario() 
    {
        transform.Translate(Vector3.down * velocidadedoadversario * Time.deltaTime);
    }

    private void Atirar()
    {
        tempoAtualEntreOsTiros -= Time.deltaTime;

        if (tempoAtualEntreOsTiros <= 0)
        {
            Instantiate(Tiro, localDoDisparo.position, Quaternion.Euler(0f, 0f, 90f));
            tempoAtualEntreOsTiros = tempoMaximoEntreOsTiros;
        }
        else
        {
            tempoAtualEntreOsTiros -= 1;
        }
    }
}
