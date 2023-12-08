using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUpText : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float disableTime;
    public static int scoreValue = 1500;
    TextMeshPro textMesh;
    void OnEnable()
    {

        Invoke("Disable",disableTime);
        textMesh.text = scoreValue.ToString();
        Score.instance.currentScore += scoreValue;
    }

    // Update is called once per frame
    void Start()
    {
        textMesh.GetComponent<TextMeshPro>();
        
    }
    void Disable()
    {
        gameObject.SetActive(false);
    }
}
