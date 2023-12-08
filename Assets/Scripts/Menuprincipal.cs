using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuprincipal : MonoBehaviour
{
   
   [SerializeField] private GameObject painelMenuInicial;
   [SerializeField] private GameObject painelOpcoes;

  public void jogar()
    {
        SceneManager.LoadScene(1);
    }
public void AbrirOpcoes()
    {
       painelMenuInicial.SetActive(false);
       painelOpcoes.SetActive(true);
    }
    public void FechaOpcoes()
    {
       painelMenuInicial.SetActive(true);
       painelOpcoes.SetActive(false);
    }
    public void sairdojogo()
    {
        Debug.Log("SAIR DO JOGO");
        Application.Quit();
            
        
    }
}
