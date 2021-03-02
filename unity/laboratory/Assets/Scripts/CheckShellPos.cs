using System;
using UnityEngine;

public class CheckShellPos : MonoBehaviour
{
    public TaskLogic taskLogic;
    public float centerLeftBound;
    public float centerRightBound;

    private void Update()
    {
        if (transform.localPosition.y > centerLeftBound || transform.localPosition.y < centerRightBound) return;
        
        taskLogic.TaskIsDone();
        Destroy(this);
    }
}