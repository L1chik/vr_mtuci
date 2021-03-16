using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    private List<Task> tasks;
    public Task currentTask {get; private set;}
    public int lastTask { get; private set; }

    // Start is called before the first frame update
    void Awake() {
        Messenger.AddListener(MessageEvent.NEXT_TASK, OnTaskSwitch);
        Messenger<Task[]>.AddListener(MessageEvent.RESET_TASKS, OnTasksReset);
    }
    void OnDestroy() {
        Messenger.RemoveListener(MessageEvent.NEXT_TASK, OnTaskSwitch);
        Messenger<Task[]>.RemoveListener(MessageEvent.RESET_TASKS, OnTasksReset);
    }
    
    public void Start() {

    }

    public void OnTasksReset(Task[] tasks) {
        this.tasks = tasks.ToList();
        currentTask = this.tasks[0];
    }

    public void OnTaskSwitch() {
        currentTask = this.tasks[this.tasks.IndexOf(currentTask) + 1];
        Debug.Log(string.Format("Switched to task {0}", currentTask.name));
    }
}
