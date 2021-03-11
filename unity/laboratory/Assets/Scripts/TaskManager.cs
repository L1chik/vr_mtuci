using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public int currentTask {get; private set;}

    public int lastTask { get; private set; }

    // Start is called before the first frame update
    void Awake() {
        Messenger.AddListener(MessageEvent.NEXT_TASK, OnTaskSwitch);
    }
    void OnDestroy() {
        Messenger.RemoveListener(MessageEvent.NEXT_TASK, OnTaskSwitch);
    }
    
    public void Start() {
        currentTask = 0;
    }

    public void OnTaskSwitch() {
        currentTask++;
        Debug.Log(string.Format("Switched to task {0}", currentTask));
    }
}
