using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState 
{

    protected BossStateMachine bossStateMachine;
    protected Boss boss;
    
    public BossState(Boss boss, BossStateMachine bossStateMachine )
    {
        this.boss = boss;
        this.bossStateMachine = bossStateMachine;
    } 
    public virtual void Enter()
    {

    }
     public virtual void Update()
    {
        
    }
      public virtual void Exit()
    {
      ResetValues();
    }
      public virtual void AinimationTriggerEvent(Boss.AinimationTriggerType triggerType)
    {

    }
    public virtual void ResetValues()
    {

    }
   
    
}
