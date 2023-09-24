using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItenDrop : MonoBehaviour
{
    [System.Serializable]
   public class Iten
    {
        public string name = "A common Iten";
        public GameObject itenObject;
        public GameObject itenIconPrefab;
        public string itenDescription = "This is a helpful iten";
        int id;
        int moduleId;
    }
    [System.Serializable]
    public class ModulesPart
    {
        public string name = "VirusModule";
        public List<Iten> itens;
       
    }
   public List<ModulesPart> itensModuleList;

    //dropa um item aleatorio ou um item especificado pelo seu moduleid e itenId
    public Iten GetItenDroppedRandomily(int modulePartId = -1,int itenToDropId = -1)
    {

        modulePartId = modulePartId == -1?Random.Range(0,itensModuleList.Count):modulePartId;
         itenToDropId = itenToDropId == -1?Random.Range(0,itensModuleList[modulePartId].itens.Count):itenToDropId;
        Iten DropIten = itensModuleList[modulePartId].itens[itenToDropId];
        //evita itens repetidos removendo-o da lista de itens
        itensModuleList[modulePartId].itens.RemoveAt(itenToDropId);
        return DropIten;
     
      
    
    }

}
