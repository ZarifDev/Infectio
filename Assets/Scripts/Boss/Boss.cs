using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
  
   public BossStateMachine StateMachine;
   public IdleBossState IdleState;
   public enum AinimationTriggerType
   {
    EnemyDamaged,
    Hit
   }

   [SerializeField]  private IdleBossSOBase idleBossBase;
   //usando instancias da referencia original para cada inimigo modificar seu proprio Scriptable object e nao de todos
    [HideInInspector] public IdleBossSOBase idleBossBaseInstance;

    protected void Awake()
    {
    StateMachine = new BossStateMachine();

    idleBossBaseInstance = Instantiate(idleBossBase);   
    IdleState = new IdleBossState(this, StateMachine);
    }
     protected void Start()
    {
        idleBossBaseInstance.Initialize(gameObject,this);
        //inicia o estado como idle
        StateMachine.Initialize(IdleState);
    }

    protected void AinimationTriggerEvent(AinimationTriggerType triggerType)
    {
        StateMachine.currentBossState.AinimationTriggerEvent(triggerType);
    }
    // Update is called once per frame
    protected void Update()
    {
        StateMachine.currentBossState.Update();
        
    }
}
