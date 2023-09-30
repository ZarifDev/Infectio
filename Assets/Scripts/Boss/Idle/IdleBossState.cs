using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class IdleBossState : BossState
{
   public IdleBossState (Boss boss, BossStateMachine bossStateMachine) : base (boss,bossStateMachine )
   {

   }
    public override void Enter()
    {
        base.Enter();
        boss.idleBossBaseInstance.DoEnterCustomCode();
    }
    public override void Exit()
    {
        base.Exit();
        boss.idleBossBaseInstance.DoExitCustomCode();
    }
    public override void Update()
    {
        base.Update();
        boss.idleBossBaseInstance.DoUpdateCustomCode();
    }
    public override void AinimationTriggerEvent(Boss.AinimationTriggerType triggerType)
    {
      boss.idleBossBaseInstance.DoCustomAinimationTriggerEvent(triggerType);
    }

    public override void ResetValues()
    {
        boss.idleBossBaseInstance.DoResetCustomCodeValues();
    }

   
  
}
