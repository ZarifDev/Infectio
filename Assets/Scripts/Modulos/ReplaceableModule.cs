using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceableModule : MonoBehaviour
{
    static ModuleMananger moduleMananger;
    void Start()
    {
        if(moduleMananger == null)
        {
            moduleMananger = GameObject.FindGameObjectWithTag("Player").GetComponent<ModuleMananger>();
        }
        moduleMananger.ReplacePlayerCurrentModule(this.gameObject);
    
    }

}
