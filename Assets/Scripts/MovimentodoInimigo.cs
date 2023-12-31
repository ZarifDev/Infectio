using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentodoInimigo : MonoBehaviour
{
    [SerializeField] private Vector3[] pontosDoCaminho;
    private int pontoAtual;

    [SerializeField] private float velocidadeDeMovimento;
     

    // Start is called before the first frame update
    void Start()
    {
       
    }


    // Update is called once per frame
    void Update()
    {
        MovimentarInimigo();    
    }
    private void MovimentarInimigo()
    {
        transform.position = Vector2.MoveTowards(transform.position, pontosDoCaminho[pontoAtual], velocidadeDeMovimento * Time.deltaTime);
       if (transform.position == pontosDoCaminho[pontoAtual])
        {
            pontoAtual += 1;

            if (pontoAtual >= pontosDoCaminho.Length)
            {
                pontoAtual = 0; 
            }
        }

    }

}
