using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MutationCell : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ItenDrop itenDrop;
    [SerializeField] ItenDrop.Iten[] itens;
    [SerializeField] GameObject[] slots;
    [SerializeField] TMP_Text descriptionText;
    [SerializeField] int currentSlotSelectionId;
    void Start()
    {
        itens = new ItenDrop.Iten[slots.Length];
        GenerateItens();
    }

    // Update is called once per frame
    void Update()
    {
         MoveSelection ();
    }
    void GenerateItens()
    {
        for (int slotid = 0; slotid < slots.Length; slotid++)
        {
                itens[slotid] = itenDrop.GetItenDroppedRandomily(slotid);
                slots[slotid] =  itens[slotid].itenIconPrefab; 
        }
    }
    void MoveSelection ()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
        currentSlotSelectionId--;
          ChangeSelectionProprites();
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
        currentSlotSelectionId++;
        ChangeSelectionProprites();
        }

    }
    void ChangeSelectionProprites()
    {
        currentSlotSelectionId = Mathf.Clamp(currentSlotSelectionId,0,slots.Length-1);
        descriptionText.text =  "<b>"+itens[currentSlotSelectionId].name + "</b>" +"<br>" + itens[currentSlotSelectionId].itenDescription;
    }
}
