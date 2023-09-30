using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateMachine
{
    public BossState currentBossState{get;set;}
   
    public void Initialize(BossState startingState )
    {
        currentBossState = startingState;
        currentBossState.Enter();
    }
    public void ChangeState(BossState newState)
    {
        currentBossState.Exit();
        currentBossState = newState;
        currentBossState.Enter();
    }
}
