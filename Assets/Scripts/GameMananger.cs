using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMananger : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameMananger instance;
    public GameObject gameOverMenu;
    public GameObject PauseMenu;
    public GameObject VictoryMenu;
    void Awake()
    {
    

    if(instance==null)
    {
        instance= this;
    }
       
    }
   
    void Start()
    {
    gameOverMenu = GameObject.Find("GameOverMenu");
    PauseMenu = GameObject.Find("PauseMenu");
    VictoryMenu = GameObject.Find("VictoryMenu");
    gameOverMenu.SetActive(false);
     VictoryMenu.SetActive(false);
    print("s");
    Resume();
    }
     public void GameOver()
    {
      Time.timeScale = 0;//pausa o tempo
      gameOverMenu.SetActive(true);
    }
    public void Pause()
    {
    Time.timeScale = 0;
    PauseMenu.SetActive(true);
    }
    public void Resume()
    {
    Time.timeScale = 1;
      PauseMenu.SetActive(false);
    }
     public void Restart()
    {
//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
SceneManager.LoadScene(0);
    }

    public void GoToNextScene()
    {
    int nextSceneNumber = (SceneManager.GetActiveScene().buildIndex)+1;
     if(SceneManager.sceneCountInBuildSettings>nextSceneNumber)
     {
        SceneManager.LoadScene(nextSceneNumber);
     }else
     {
   
        VictoryMenu.SetActive(true);
     }
          print(nextSceneNumber);
        print(SceneManager.sceneCountInBuildSettings);
    }

}
