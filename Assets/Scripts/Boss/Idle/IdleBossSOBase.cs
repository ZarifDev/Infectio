using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBossSOBase : ScriptableObject
{
    protected Boss boss;
    protected Transform transform;
    protected GameObject gameObject;
    protected Transform playerTransform;
    protected Animator animator;
    // Start is called before the first frame update
   
    public virtual void Initialize(GameObject gameObject, Boss boss)
    {

    }
      public virtual void DoEnterCustomCode()
    {

    }
     public virtual void DoUpdateCustomCode()
    {
        
    }
      public virtual void DoExitCustomCode()
    {
        DoResetCustomCodeValues();
    }
      public virtual void DoCustomAinimationTriggerEvent(Boss.AinimationTriggerType triggerType)
    {

    }
    public virtual void DoResetCustomCodeValues()
    {

    }

}
