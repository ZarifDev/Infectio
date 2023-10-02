using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [System.Serializable]
    public class Item // Classe representando um item
    {
        public string name = "A common Item"; // Nome padr�o do item
        public GameObject itemObject; // Objeto do item
        public GameObject itemIconPrefab; // �cone do item
        public string itemDescription = "This is a helpful item"; // Descri��o do item
    }

    [System.Serializable]
    public class ModulesPart // Classe representando um m�dulo que cont�m uma lista de itens
    {
        public string name = "VirusModule"; // Nome do m�dulo
        public List<Item> items; // Lista de itens no m�dulo
    }

    public List<ModulesPart> itemsModuleList; // Lista de m�dulos de itens dispon�veis para dropar

    // Dropa um item aleatoriamente ou um item especificado pelo seu moduleID e itemID
    public Item GetItemDroppedRandomly(int modulePartId = -1, int itemToDropId = -1)
    {
        // Se modulePartId ou itemToDropId n�o forem especificados, seleciona um aleat�rio
        modulePartId = modulePartId == -1 ? Random.Range(0, itemsModuleList.Count) : modulePartId;
        itemToDropId = itemToDropId == -1 ? Random.Range(0, itemsModuleList[modulePartId].items.Count) : itemToDropId;

        Item dropItem = itemsModuleList[modulePartId].items[itemToDropId]; // Obt�m o item para dropar

        // Evita itens repetidos removendo-o da lista de itens
        itemsModuleList[modulePartId].items.RemoveAt(itemToDropId);

        return dropItem; // Retorna o item dropado
    }
}
