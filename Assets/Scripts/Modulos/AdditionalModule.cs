using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalModule : MonoBehaviour
{
    // Start is called before the first frame update
    static ModuleMananger moduleMananger;
    void Start()
    {
        if(moduleMananger == null)
        {
            moduleMananger = GameObject.FindGameObjectWithTag("Player").GetComponent<ModuleMananger>();
        }
        moduleMananger.AddModuleToPlayer(this.gameObject);
    }

    // Update is called once per frame
   
}
