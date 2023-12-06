using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameData instance;
    public List<ItemDrop.ModulesPart> AllGameItems;
    public List<ItemDrop.ModulesPart> AllUnlockedGameItems;
    public ItemDrop.Item InitialItem;
    public int InitialItemId;
  
    void Awake()
    {
        if(instance != null && instance != this)
      {
        Destroy(this.gameObject);
      }else
      {
       instance =this;
       DontDestroyOnLoad(instance.gameObject);
      }
      PlayerPrefs.SetString("LevelHealModule(Clone)","Unlocked");  
       
    }
   void Start()
   {
    
   }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckUnlockedItens()
    {   
        InitialItemId = PlayerPrefs.HasKey("InitialModule")?PlayerPrefs.GetInt("InitialModule"):0;
        for (int m= 0; m < AllGameItems.Count; m++)
        {
           AllUnlockedGameItems[m].items.Clear();   
          for (int i = 0; i <  AllGameItems[m].items.Count; i++)
          {
            if(PlayerPrefs.HasKey(AllGameItems[m].items[i].itemObject.name + "(Clone)"))
            {
               AllUnlockedGameItems[m].items.Add(AllGameItems[m].items[i]);
            }
          }
        }
    }

    
}
