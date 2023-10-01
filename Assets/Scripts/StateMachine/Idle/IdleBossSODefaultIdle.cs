using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Default Idle", menuName ="BossStateLogic/Idle/Default")]
public class IdleBossSODefaultIdle : IdleBossSOBase
{
    //codigo
   [SerializeField] float movementSpeed;

  

    public override void Initialize(GameObject gameObject, Boss boss)
    {
        base.Initialize(gameObject, boss);
    }

    public override void DoEnterCustomCode()
    {
        base.DoEnterCustomCode();
        Debug.Log("entrei no estado idle");
    }

    public override void DoUpdateCustomCode()
    {
        base.DoUpdateCustomCode();
        Debug.Log("to parado sem a velocidade :"+ movementSpeed);
    }

    public override void DoExitCustomCode()
    {
        base.DoExitCustomCode();
        //codigo
    }

    public override void DoCustomAinimationTriggerEvent(Boss.AinimationTriggerType triggerType)
    {
        base.DoCustomAinimationTriggerEvent(triggerType);
    }

    public override void DoResetCustomCodeValues()
    {
        base.DoResetCustomCodeValues();
    }

   
 
  
}
