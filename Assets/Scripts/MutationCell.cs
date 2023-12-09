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
    bool moduleSelected;
    [SerializeField] float movementSpeed = 5;
     GameObject player;
    ModuleMananger moduleMananger;
    [SerializeField] GameObject VirusClones;
    AudioSource audioSource;
      [SerializeField] AudioClip changeSelection;
        [SerializeField] AudioClip select;
    
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
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        moduleMananger = player.GetComponent<ModuleMananger>();
        itens = new ItemDrop.Item[slotIten.Length];
        if(slotItenMeshFilter.Length<=0)
        {
        GetMeshFiltersReferences();
        }
        RemoveCurrentPlayerItensToDrop();
        GenerateItens();
    }
    
    void RemoveCurrentPlayerItensToDrop()
    {

        for (int moduleID = 0; moduleID < moduleMananger.CurrentModules.Count; moduleID++)
        {
      
            if(moduleMananger.CurrentModules[moduleID].items.Count > 0){

                for (int playerIten = 0; playerIten < moduleMananger.CurrentModules[moduleID].items.Count; playerIten++)
                { 
                    for (int i = 0; i <  itenDrop.itemsModuleList[moduleID].items.Count; i++)
                    {
                        //cheaca se o modulo selecionado ja existe no player e se nao tem o script de modulo stacavel, e remove da lista de drops
                        if( itenDrop.itemsModuleList[moduleID].items[i].name == moduleMananger.CurrentModules[moduleID].items[playerIten].name &&itenDrop.itemsModuleList[moduleID].items[i].itemObject.GetComponent<StackableModule>()==null)
                        {
                             itenDrop.itemsModuleList[moduleID].items.RemoveAt(i);
                        }
                    }
                
             
                }
            }
        }
      
    }
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            RemoveCurrentPlayerItensToDrop();
            GenerateItens();
        }
        if(canSelectModules )
        {
         MoveSelection ();
        }
         
        MoveCell();
       if(transform.position.x < -15)
       {
        Destroy(gameObject);
        LevelSpawner.enemiesActiveInScene.Remove(gameObject);
       }
    }
    void MoveCell()
    {
        if(transform.position.x >= 0 && !moduleSelected || !canSelectModules){
          transform.Translate(Vector3.left * Time.deltaTime*movementSpeed); 
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
          PlaySound(changeSelection);   
        }
        if(Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.DownArrow))
        {
        PlaySound(changeSelection);
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
        moduleMananger.CurrentModules[currentSlotSelectionId].items.Add(itens[currentSlotSelectionId]);
        Instantiate(itens[currentSlotSelectionId].itemObject,slotIten[currentSlotSelectionId].transform.position,itens[currentSlotSelectionId].itemObject.transform.rotation);
        slotItenMeshFilter[currentSlotSelectionId].sharedMesh = null;
        slotItenMeshRenderer[currentSlotSelectionId].sharedMaterial = null;
        canSelectModules = false;
        descriptionText.text ="";
        GameObject proli = Instantiate(VirusClones, player.transform.position,Quaternion.identity);
         proli.transform.SetParent(transform);
        Player.playerCantDoNothing = false;
         player.transform.SetParent(null);
         player.transform.localPosition = new Vector3(transform.position.x + (transform.localScale.x/2),transform.position.y,0);
        moduleSelected = true;
        PlaySound(select);

    }
    void ChangeSelectionProprites()
    {   
        currentSlotSelectionId = Mathf.Clamp(currentSlotSelectionId,0,2);
        if(PlayerPrefs.HasKey(itens[currentSlotSelectionId].itemObject.name+"(Clone)")){
        currentSlotSelectionId = Mathf.Clamp(currentSlotSelectionId,0,slotIten.Length-1);
        descriptionText.text =  "<b>"+itens[currentSlotSelectionId].name + "</b>" +"<br>" + itens[currentSlotSelectionId].itemDescription;
        }else
        {
             descriptionText.text =  "<b>Mysterious Mutation</b>" + "<br>" +"select to unlock it" ;
        }
       
        
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
    
    private void OnTriggerStay(Collider other) {

        if(other.gameObject.tag == "Player" && moduleSelected == false)
        {
            canSelectModules =true;
            Player.playerCantDoNothing = true;
            player.transform.SetParent(transform);
            ChangeSelectionProprites();
        }
    }
    void PlaySound(AudioClip clip)
	{
		audioSource.PlayOneShot(clip);
	}
}
