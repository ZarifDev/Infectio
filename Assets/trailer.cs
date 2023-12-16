using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailer : MonoBehaviour
{
    public GameObject[] players;
    int i;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            players[i].SetActive(false);
            i++;
            players[i].SetActive(true);
        }        
    }
}
