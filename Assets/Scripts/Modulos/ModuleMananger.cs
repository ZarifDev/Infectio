using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleMananger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject currentHeadModule;
    public GameObject currentBodyModule;    
    public GameObject currentFeetModule;
    public Transform headModulesLocation;
    public Transform bodyModulesLocation;    
    public Transform feetModulesLocation;

    public void AddModuleToPlayer(GameObject ModuleToAdd)
    {
        if(ModuleToAdd.tag == "HeadModule")
        {
            ModuleToAdd.transform.SetParent(headModulesLocation);

        }else if(ModuleToAdd.tag == "BodyModule")
        {
            ModuleToAdd.transform.SetParent(bodyModulesLocation);

        }else if(ModuleToAdd.tag == "FeetModule")
        {
            ModuleToAdd.transform.SetParent(feetModulesLocation);
        }
         print("!!Atenção!! você precisa colocar uma tag nesse objeto, FeetModule ou BodyModule ou HeadModule");
          ModuleToAdd.transform.localPosition = Vector3.zero;
    }
     public void ReplacePlayerCurrentModule(GameObject ModuleToRaplace)
    {
       
        if(ModuleToRaplace.tag == "HeadModule")
        {
            ModuleToRaplace.transform.SetParent(headModulesLocation);
            Destroy(currentHeadModule);
            currentHeadModule = ModuleToRaplace;

        }else if(ModuleToRaplace.tag == "BodyModule")
        {
            ModuleToRaplace.transform.SetParent(bodyModulesLocation);
             Destroy(currentBodyModule);
            currentBodyModule = ModuleToRaplace;

        }else if(ModuleToRaplace.tag == "FeetModule")
        {
            ModuleToRaplace.transform.SetParent(feetModulesLocation);
             Destroy(currentFeetModule);
            currentFeetModule = ModuleToRaplace;
        }else
        {
            print("!!Atenção!! você precisa colocar uma tag nesse objeto, FeetModule ou BodyModule ou HeadModule");
        }
        ModuleToRaplace.transform.localPosition = Vector3.zero;
    }
}
