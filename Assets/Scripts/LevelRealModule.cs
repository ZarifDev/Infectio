using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRealModule : MonoBehaviour
{
    // Start is called before the first frame update
    int currentLevel = 0;
    int lastLevel=0; 

    // Start is called before the first frame update

    void Start()
    {
      
        lastLevel = SceneManager.GetActiveScene().buildIndex;
        currentLevel = lastLevel;
       

    }
    

    // Update is called once per frame
    void Update()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        if(currentLevel != lastLevel)
        {
        lastLevel = currentLevel;
        Player.instance.Cura(Player.instance.vidaMaxima);
        }
    }
}
