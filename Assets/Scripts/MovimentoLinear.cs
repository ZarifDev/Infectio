using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoLinear : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidadedoadversario = 3;
     float centroDaTelaOffset = 4; 
     private void Start() {
        transform.position = new Vector3(transform.position.x+ Random.Range(0,3),transform.position.y,transform.position.z);
        centroDaTelaOffset = Random.Range(centroDaTelaOffset,centroDaTelaOffset+2);
     }
    void Update()
    {
        MovimentarAdversario();
   
    }
    private void MovimentarAdversario() 
    {
        if(transform.position.x >= 0 + centroDaTelaOffset ){
        transform.Translate(Vector3.left * velocidadedoadversario * Time.deltaTime);
        }
    }
}
