using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InitialModuleSelector : MonoBehaviour
{

     [SerializeField] GameObject SelectionHolder;
    [SerializeField] List <ItemDrop.Item> unlockedItens;
    [SerializeField]List <ItemDrop.Item> lockedItens;
    [SerializeField] GameObject[] slotIten;
    [SerializeField] GameObject lockedSimbol;
     [SerializeField]  MeshFilter[] slotItenMeshFilter;
     [SerializeField] MeshRenderer[]  slotItenMeshRenderer;
    [SerializeField] TMP_Text descriptionText;
    [SerializeField] int currentSlotSelectionId;
    [SerializeField] float selectAnimTime = 3;
    [SerializeField]  float selectAnimElapsedTime;
    [SerializeField] bool canSelectModules = true;
    bool moduleSelected;
    ModuleMananger moduleMananger;
    AudioSource audioSource;
    [SerializeField] AudioClip changeSelection;
    [SerializeField] AudioClip nullSelection;
    [SerializeField] AudioClip select;
    [SerializeField] AudioClip selectLocked;

    
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
        GameData.instance.CheckUnlockedItens();
        audioSource = GetComponent<AudioSource>();

        for (int m = 0; m < GameData.instance.AllGameItems.Count; m++)
        {

            for (int i = 0; i < GameData.instance.AllGameItems[m].items.Count; i++)
            {
            lockedItens.Add(GameData.instance.AllGameItems[m].items[i]);
            }
        }


        for (int m = 0; m < GameData.instance.AllUnlockedGameItems.Count; m++)
        {

            for (int i = 0; i < GameData.instance.AllUnlockedGameItems[m].items.Count; i++)
            {
           
            unlockedItens.Add(GameData.instance.AllUnlockedGameItems[m].items[i]);
             lockedItens.Remove(GameData.instance.AllUnlockedGameItems[m].items[i]);
            }
        }

        if(slotItenMeshFilter.Length<=0)
        {
        GetMeshFiltersReferences();
        }
    
        GenerateItens();
        currentSlotSelectionId = GameData.instance.InitialItemId;
        ChangeSelectionProprites();
    }

    // Update is called once per frame
    void Update()
    {

        if(canSelectModules )
        {
         MoveSelection ();
        }
         

       if(transform.position.x < -15)
       {
        Destroy(gameObject);
        LevelSpawner.enemiesActiveInScene.Remove(gameObject);
       }
    }
   

    void GenerateItens()
    {
        for (int slotid = 0; slotid < unlockedItens.Count; slotid++)
        {

       slotItenMeshFilter[slotid].sharedMesh = unlockedItens[slotid].itemIconPrefab.GetComponent<MeshFilter>().sharedMesh;
       slotItenMeshRenderer[slotid].sharedMaterial = unlockedItens[slotid].itemIconPrefab.GetComponent<MeshRenderer>().sharedMaterial;
                // print(ItenIcon);
             
        }   
           for (int i = unlockedItens.Count; i < lockedItens.Count; i++)
        {

       slotItenMeshFilter[i].sharedMesh = lockedItens[i].itemIconPrefab.GetComponent<MeshFilter>().sharedMesh;
      // slotItenMeshRenderer[i].sharedMaterial = unlockedItens[i].itemIconPrefab.GetComponent<MeshRenderer>().sharedMaterial;
                // print(ItenIcon);
             
        }   
    }
    void MoveSelection ()
    {
        if(Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.LeftArrow))
        {

        currentSlotSelectionId--;
        selectAnimElapsedTime=0;
          ChangeSelectionProprites();
        }
        if(Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.RightArrow))
        {
        currentSlotSelectionId++;
        selectAnimElapsedTime=0;
        ChangeSelectionProprites();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            SelectModule();
    
        }
    AnimateSelection();
    }
   public void SelectModule ()
    {
      if(currentSlotSelectionId < unlockedItens.Count){
        slotItenMeshFilter[currentSlotSelectionId].sharedMesh = null;
        slotItenMeshRenderer[currentSlotSelectionId].sharedMaterial = null;
        canSelectModules = false;
        descriptionText.text ="";
        moduleSelected = true;
        GameData.instance.InitialItem = unlockedItens[currentSlotSelectionId];
        GameData.instance.InitialItemId = currentSlotSelectionId;
        PlayerPrefs.SetInt("InitialModule",currentSlotSelectionId);
        GameMananger.instance.GoToNextScene();
        PlaySound(select);
      }else
      {
        PlaySound(selectLocked);
      }

    }
    void ChangeSelectionProprites()
    {    currentSlotSelectionId = Mathf.Clamp(currentSlotSelectionId,0,slotIten.Length-1);
        if(currentSlotSelectionId < unlockedItens.Count){
         PlaySound(changeSelection);   
        descriptionText.text =  "<b>"+unlockedItens[currentSlotSelectionId].name + "</b>" +"<br>" + "</b>" +"<br>" + unlockedItens[currentSlotSelectionId].itemDescription;
        }else
        {
             PlaySound(nullSelection); 
             descriptionText.text = "you need to unlock this item in a new run";
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
                slotIten[slotid].transform.localScale= Vector3.Lerp( slotIten[slotid].transform.localScale,Vector3.one*2f,selectionAnimationPercentage);
                SelectionHolder.transform.position = Vector3.Lerp(SelectionHolder.transform.position, new Vector3(slotid*-6, SelectionHolder.transform.position.y, SelectionHolder.transform.position.z),selectionAnimationPercentage); 
        }else
        {
                slotIten[slotid].transform.localScale= Vector3.Lerp( slotIten[slotid].transform.localScale,Vector3.one*1f,selectionAnimationPercentage);
                  
        }
           
        }
       
             
        }
    }
    
    void PlaySound(AudioClip clip)
	{
		audioSource.PlayOneShot(clip);
	}
}
