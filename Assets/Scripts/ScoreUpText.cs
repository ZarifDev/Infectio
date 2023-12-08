using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUpText : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float disableTime;
    public static int scoreValue = 1500;
    [SerializeField]TextMeshPro textMesh;
    void OnEnable()
    {
        
        Invoke("Disable",disableTime);
        if(scoreValue>0){
        textMesh.text = "+"+scoreValue.ToString();
        }else
        {
            textMesh.text = "New Module Unlocked";
        }

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
