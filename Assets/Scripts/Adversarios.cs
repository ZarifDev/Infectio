using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adversarios : MonoBehaviour
{
    public float velocidadedoadversario;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarAdversario();    
    }
    private void MovimentarAdversario() 
    {
        transform.Translate(Vector3.down * velocidadedoadversario * Time.deltaTime);
    }
}
