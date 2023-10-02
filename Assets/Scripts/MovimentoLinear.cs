using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoLinear : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidadedoadversario = 3;

    void Update()
    {
        MovimentarAdversario();
   
    }
    private void MovimentarAdversario() 
    {
        transform.Translate(Vector3.left * velocidadedoadversario * Time.deltaTime);
    }
}
