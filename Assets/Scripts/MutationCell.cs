using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MutationCell : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ItemDrop itenDrop;
    ItemDrop.Item[] itens;
    [SerializeField] GameObject[] slotIten;
     [SerializeField]  MeshFilter[] slotItenMeshFilter;
     [SerializeField] MeshRenderer[]  slotItenMeshRenderer;
    [SerializeField] TMP_Text descriptionText;
    [SerializeField] int currentSlotSelectionId;
    [SerializeField] float selectAnimTime = 3;
    [SerializeField]  float selectAnimElapsedTime;
    [SerializeField] bool canSelectModules;

    [SerializeField] GameObject player;
    
     [ContextMenu("GetComponents")]
    public void GetMeshFiltersReferences()
    { 
        slotItenMeshFilter = new MeshFilter[slotIten.Length];
        slotItenMeshRenderer = new MeshRenderer[slotIten.Length];
        for (int slotid = 0; slotid < slotIten.Length; slotid++)
        {
       slotItenMeshFilter[slotid] = slotIten[slotid].transform.GetChild(0).gameObject.GetComponent<MeshFilter>();
       slotItenMeshRenderer[slotid] = slotIten[slotid].transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();   
        }   
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        itens = new ItemDrop.Item[slotIten.Length];
        if(slotItenMeshFilter.Length<=0)
        {
            GetMeshFiltersReferences();
        }
        GenerateItens();
    }
    

    // Update is called once per frame
    void Update()
    {
        if(canSelectModules)
        {
         MoveSelection ();
        }
       
    }

    void GenerateItens()
    {
        for (int slotid = 0; slotid < slotIten.Length; slotid++)
        {
                itens[slotid] = itenDrop.GetItemDroppedRandomly(slotid);

   
       slotItenMeshFilter[slotid].sharedMesh = itens[slotid].itemIconPrefab.GetComponent<MeshFilter>().sharedMesh;
       slotItenMeshRenderer[slotid].sharedMaterial = itens[slotid].itemIconPrefab.GetComponent<MeshRenderer>().sharedMaterial;
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
        if(Input.GetKeyDown(KeyCode.Space)||Input.GetButtonDown("Fire1"))
        {

            SelectModule(itens[currentSlotSelectionId]);
    
        }
    AnimateSelection();
    }
    void SelectModule (ItemDrop.Item item )
    {
        Instantiate(itens[currentSlotSelectionId].itemObject,slotIten[currentSlotSelectionId].transform.position,Quaternion.identity);
        slotItenMeshFilter[currentSlotSelectionId].sharedMesh = null;
        slotItenMeshRenderer[currentSlotSelectionId] = null;
        canSelectModules = false;
    }
    void ChangeSelectionProprites()
    {
        currentSlotSelectionId = Mathf.Clamp(currentSlotSelectionId,0,slotIten.Length-1);
        descriptionText.text =  "<b>"+itens[currentSlotSelectionId].name + "</b>" +"<br>" + itens[currentSlotSelectionId].itemDescription;
       
        
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
    
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            canSelectModules =true;
            ChangeSelectionProprites();
        }
    }
}
