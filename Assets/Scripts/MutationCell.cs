using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MutationCell : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ItenDrop itenDrop;
    
    ItenDrop.Iten[] itens;
    [SerializeField] GameObject[] slotIten;
     [SerializeField]  MeshFilter[] slotItenMeshFilter;
     [SerializeField] MeshRenderer[]  slotItenMeshRenderer;
    [SerializeField] TMP_Text descriptionText;
    [SerializeField] int currentSlotSelectionId;
    [SerializeField] float selectAnimTime = 3;
    [SerializeField]  float selectAnimElapsedTime;
    
     [ContextMenu("GetComponents")]
    public void GetMeshFiltersReferences()
    { slotItenMeshFilter = new MeshFilter[slotIten.Length];
    slotItenMeshRenderer = new MeshRenderer[slotIten.Length];
        for (int slotid = 0; slotid < slotIten.Length; slotid++)
        {
       slotItenMeshFilter[slotid] = slotIten[slotid].transform.GetChild(0).gameObject.GetComponent<MeshFilter>();
       slotItenMeshRenderer[slotid] = slotIten[slotid].transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();   
        }   
    }
    void Start()
    {
        
        itens = new ItenDrop.Iten[slotIten.Length];
        //GenerateItens();
    }
    

    // Update is called once per frame
    void Update()
    {
         MoveSelection ();
         if(Input.GetButtonDown("Fire1"))
         {
           GenerateItens(); 
         }
    }

    void GenerateItens()
    {
        for (int slotid = 0; slotid < slotIten.Length; slotid++)
        {
                itens[slotid] = itenDrop.GetItenDroppedRandomily(slotid);

   
       slotItenMeshFilter[slotid].sharedMesh = itens[slotid].itenIconPrefab.GetComponent<MeshFilter>().sharedMesh;
       slotItenMeshRenderer[slotid].sharedMaterial = itens[slotid].itenIconPrefab.GetComponent<MeshRenderer>().sharedMaterial;
                // print(ItenIcon);
             
        }   
    }
    void MoveSelection ()
    {
        if(Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.UpArrow))
        {
        currentSlotSelectionId--;
        selectAnimElapsedTime=0;
          ChangeSelectionProprites();
        }
        if(Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.DownArrow))
        {
        currentSlotSelectionId++;
        selectAnimElapsedTime=0;
        ChangeSelectionProprites();
        }
    AnimateSelection();
    }
    void ChangeSelectionProprites()
    {
        currentSlotSelectionId = Mathf.Clamp(currentSlotSelectionId,0,slotIten.Length-1);
        descriptionText.text =  "<b>"+itens[currentSlotSelectionId].name + "</b>" +"<br>" + itens[currentSlotSelectionId].itenDescription;
       
        
    }
    void AnimateSelection()
    {
        
        selectAnimElapsedTime += Time.deltaTime;
       float selectionAnimationPercentage = selectAnimElapsedTime/selectAnimTime;
       if(selectionAnimationPercentage <=1){
        for (int slotid = 0; slotid < slotIten.Length; slotid++)
        {
              if(slotid == currentSlotSelectionId){
                slotIten[slotid].transform.localScale= Vector3.Lerp( slotIten[slotid].transform.localScale,Vector3.one*0.3f,selectionAnimationPercentage); 
        }else
        {
                slotIten[slotid].transform.localScale= Vector3.Lerp( slotIten[slotid].transform.localScale,Vector3.one*0.21f,selectionAnimationPercentage);    
        }
        }
        }
    }
}
