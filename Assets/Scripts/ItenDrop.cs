using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [System.Serializable]
    public class Item // Classe representando um item
    {
        public string name = "A common Item"; // Nome padrão do item
        public GameObject itemObject; // Objeto do item
        public GameObject itemIconPrefab; // Ícone do item
        public string itemDescription = "This is a helpful item"; // Descrição do item
    }

    [System.Serializable]
    public class ModulesPart // Classe representando um módulo que contém uma lista de itens
    {
        public string name = "VirusModule"; // Nome do módulo
        public List<Item> items; // Lista de itens no módulo
    }

    public List<ModulesPart> itemsModuleList; // Lista de módulos de itens disponíveis para dropar

    // Dropa um item aleatoriamente ou um item especificado pelo seu moduleID e itemID
    public Item GetItemDroppedRandomly(int modulePartId = -1, int itemToDropId = -1)
    {
        // Se modulePartId ou itemToDropId não forem especificados, seleciona um aleatório
        modulePartId = modulePartId == -1 ? Random.Range(0, itemsModuleList.Count) : modulePartId;
        itemToDropId = itemToDropId == -1 ? Random.Range(0, itemsModuleList[modulePartId].items.Count) : itemToDropId;

        Item dropItem = itemsModuleList[modulePartId].items[itemToDropId]; // Obtém o item para dropar

        // Evita itens repetidos removendo-o da lista de itens
        itemsModuleList[modulePartId].items.RemoveAt(itemToDropId);

        return dropItem; // Retorna o item dropado
    }
}
