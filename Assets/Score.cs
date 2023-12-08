using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    Text text;
    public static Score instance;
    public int currentScore;
    [SerializeField] GameObject scoreUp;
     private void Awake() 
    {
      if(instance != null && instance != this)
      {
        Destroy(this.gameObject);
      }else
      {
       instance =this;
      
      }
    }
    void Start()
    {
        text = GetComponent<Text>();
     
        if(!PlayerPrefs.HasKey("BestScore"))
        {
        PlayerPrefs.SetInt("BestScore",currentScore);
        }
        text.text = "BestScore: "+ PlayerPrefs.GetInt("BestScore").ToString();
    }

    // Update is called once per frame
    public void AddScore(int value)
    {
        scoreUp = GameMananger.instance.ScoreUp;
        currentScore += value;
        text.text = "SCORE: "+currentScore.ToString();
        ScoreUpText.scoreValue = value;
        scoreUp.SetActive(true);
        if(currentScore > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore",currentScore);
        }
    }
}
