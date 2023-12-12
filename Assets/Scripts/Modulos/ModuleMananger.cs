using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModuleMananger : MonoBehaviour
{
    // Replaceble modules
    public GameObject currentHeadModule;
    public GameObject currentBodyModule;    
    public GameObject currentFeetModule;

    // Modules Positions
    public Transform headModulesLocation;
    public Transform bodyModulesLocation;    
    public Transform feetModulesLocation;
    
    public List<ItemDrop.ModulesPart> CurrentModules;
    public List<ItemDrop.Item> CurrentUnlockedModules;

    public void AddModuleToPlayer(GameObject ModuleToAdd)
    {
        if(ModuleToAdd.tag == "HeadModule")
        {
            ModuleToAdd.transform.SetParent(headModulesLocation);
            UnlockModuleChecker(ModuleToAdd.name,0);

        }else if(ModuleToAdd.tag == "BodyModule")
        {
            ModuleToAdd.transform.SetParent(bodyModulesLocation);
            UnlockModuleChecker(ModuleToAdd.name,1);

        }else if(ModuleToAdd.tag == "FeetModule")
        {
            ModuleToAdd.transform.SetParent(feetModulesLocation);
            UnlockModuleChecker(ModuleToAdd.name,2);
        }else{
         Debug.LogErrorFormat("!!Atenção!! você precisa colocar uma tag nesse objeto, FeetModule, BodyModule ou HeadModule");
        }
          ModuleToAdd.transform.localPosition = Vector3.zero;
        ModuleToAdd.transform.localScale = Vector3.one;
    }
    void Start() 
    {
        if(GameData.instance.InitialItem!= null)
        {
            addInitalModuleToList();
        }
        
    }
    void addInitalModuleToList()
    {   
       GameObject ModuleToRaplace = GameData.instance.InitialItem.itemObject;

         if(ModuleToRaplace.tag == "HeadModule")
        {
          CurrentModules[0].items.Add(GameData.instance.InitialItem);
         

        }else if(ModuleToRaplace.tag == "BodyModule")
        {
             CurrentModules[1].items.Add(GameData.instance.InitialItem);

        }else if(ModuleToRaplace.tag == "FeetModule")
        {
             CurrentModules[2].items.Add(GameData.instance.InitialItem);
        }else
        {
            Debug.LogErrorFormat("!!Atenção!! você precisa colocar uma tag nesse objeto, FeetModule, BodyModule ou HeadModule");
        }
    }
     public void ReplacePlayerCurrentModule(GameObject ModuleToRaplace)
    {
       
        if(ModuleToRaplace.tag == "HeadModule")
        {
            RemoveModuleFromList(currentHeadModule,0);
            UnlockModuleChecker(ModuleToRaplace.name,0);
            ModuleToRaplace.transform.SetParent(headModulesLocation);
            Destroy(currentHeadModule);
            currentHeadModule = ModuleToRaplace;
         

        }else if(ModuleToRaplace.tag == "BodyModule")
        {
              RemoveModuleFromList(currentBodyModule,1);
                UnlockModuleChecker(ModuleToRaplace.name,1);
            ModuleToRaplace.transform.SetParent(bodyModulesLocation);
             Destroy(currentBodyModule);
            currentBodyModule = ModuleToRaplace;

        }else if(ModuleToRaplace.tag == "FeetModule")
        {
            RemoveModuleFromList(currentFeetModule,2);
            UnlockModuleChecker(ModuleToRaplace.name,2);
            ModuleToRaplace.transform.SetParent(feetModulesLocation);
             Destroy(currentFeetModule);
            currentFeetModule = ModuleToRaplace;
        }else
        {
            Debug.LogErrorFormat("!!Atenção!! você precisa colocar uma tag nesse objeto, FeetModule, BodyModule ou HeadModule");
        }
        ModuleToRaplace.transform.localPosition = Vector3.zero;
        ModuleToRaplace.transform.localScale = Vector3.one;
        
    }
    void RemoveModuleFromList(GameObject currentModule, int ModuleTypeId)
    {

      for ( int i = 0; i < CurrentModules[ModuleTypeId].items.Count; i++)
        {

            if(CurrentModules[ModuleTypeId].items[i].itemObject.name+"(Clone)" == currentModule.name||CurrentModules[ModuleTypeId].items[i].itemObject.name == currentModule.name)
            {
                ItemDrop.Item objectToRemove = CurrentModules[ModuleTypeId].items[i];
                CurrentModules[ModuleTypeId].items.Remove(objectToRemove);

            }
             
        }

    }
    public void UnlockModuleChecker(string moduleToCheckName,int ModuleTypeId )
    {
        if(!PlayerPrefs.HasKey(moduleToCheckName))
        {
           
        for (int i = 0; i < GameData.instance.AllGameItems[ModuleTypeId].items.Count; i++)
        {
                
            if(GameData.instance.AllGameItems[ModuleTypeId].items[i].itemObject.name+"(Clone)" == moduleToCheckName)
            {
            CurrentUnlockedModules.Add(GameData.instance.AllGameItems[ModuleTypeId].items[i]);
            PlayerPrefs.SetString(moduleToCheckName,"Unlocked");
            print(GameData.instance.AllGameItems[ModuleTypeId].items[i].itemObject.name+ ", now is unlocked");
            Score.instance.AddScore(0);
            break;
            }
        }
    }else
    {
         print(moduleToCheckName+", ja está desbloqueado ");
    }
}
    public void ClearData()
    {
        PlayerPrefs.DeleteAll();
            
    }
}
