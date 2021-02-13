using UnityEngine;

public abstract class ATaskFuncs : MonoBehaviour
{
    public virtual bool CheckRequirements()
    {
        return true;
    }

    public virtual void HandleIsChecked()
    {
    }
    
    public virtual void HandleInvalid()
    {
    }

    public virtual void HandleTaskIsDone(string taskName)
    {
    }
}