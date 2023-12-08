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
     public GameObject score;
    public GameObject VictoryMenu;
    public GameObject ScoreUp;
    public bool paused;
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
    if(Score.instance){
    score = Score.instance.gameObject;
    }
    gameOverMenu?.SetActive(false);
     VictoryMenu?.SetActive(false);
     ScoreUp?.SetActive(false);
    Resume();
    }
    void Update()
    {

    if(Input.GetKeyDown(KeyCode.Escape))
      {
        if(!paused){
        Pause();
        }else
        {
        Resume();
        }
      }
      if(Input.GetKeyDown(KeyCode.Delete))
      {
    PlayerPrefs.DeleteAll();
      }
    }
     public void GameOver()
    {
      Time.timeScale = 0;//pausa o tempo
      gameOverMenu.SetActive(true);
       Destroy(Player.instance.gameObject);
    }
    public void Pause()
    {
    Time.timeScale = 0;
    PauseMenu.SetActive(true);
    paused = true;
    }
    public void Resume()
    {
    Time.timeScale = 1;
    PauseMenu?.SetActive(false);
    paused = false;
    }
     public void Restart()
    {

      if(Player.instance  != null){
    Destroy(Player.instance.gameObject);
        }
    SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        if(Player.instance  != null){
    Destroy(Player.instance.gameObject);
    Destroy(score);
        }
    SceneManager.LoadScene(0);
    }

    public void GoToNextScene()
    {
    int nextSceneNumber = (SceneManager.GetActiveScene().buildIndex)+1;
     if(SceneManager.sceneCountInBuildSettings>nextSceneNumber)
     {
      if(Player.instance){
        DontDestroyOnLoad(Player.instance.gameObject);
        DontDestroyOnLoad(score);
      }
        SceneManager.LoadScene(nextSceneNumber);
     }else
     {
        
        VictoryMenu?.SetActive(true);
     }
          print(nextSceneNumber);
        print(SceneManager.sceneCountInBuildSettings);
    }
    
}
