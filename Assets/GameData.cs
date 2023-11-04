using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameData instance;
    void Awake()
    {
        if(instance != null && instance != this)
      {
        Destroy(this.gameObject);
      }else
      {
       instance =this;
       DontDestroyOnLoad(instance.gameObject);
      }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
