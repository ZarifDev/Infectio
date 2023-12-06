using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [System.Serializable]
    public class Item 
    {
        public string name = "A common Item"; 
        public GameObject itemObject;
        public GameObject itemIconPrefab; 
        public string itemDescription = "This is a helpful item"; 
    }

    [System.Serializable]
    public class ModulesPart 
    {
        public string name = "VirusModule"; 
        public List<Item> items; // Lista de itens no modulo
    }

    public List<ModulesPart> itemsModuleList; // Lista de modulos de itens disponiveis para dropar

    // Dropa um item aleatoriamente ou um item especificado pelo seu moduleID e itemID
    public Item GetItemDroppedRandomly(int modulePartId = -1, int itemToDropId = -1)
    {
        // Se modulePartId ou itemToDropId não forem especificados, seleciona um aleatorio
        modulePartId = modulePartId == -1 ? Random.Range(0, itemsModuleList.Count) : modulePartId;
        itemToDropId = itemToDropId == -1 ? Random.Range(0, itemsModuleList[modulePartId].items.Count) : itemToDropId;

        Item dropItem = itemsModuleList[modulePartId].items[itemToDropId]; // Obtem o item para dropar

        // Evita itens repetidos removendo-o da lista de itens
       // itemsModuleList[modulePartId].items.RemoveAt(itemToDropId);

        return dropItem; // Retorna o item dropado
    }
}
