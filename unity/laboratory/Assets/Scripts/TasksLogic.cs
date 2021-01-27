using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TasksLogic : MonoBehaviour
{
    [SerializeField] private Text textComponent;

    private Task[] _tasks;
    private int _currentTaskInd;
    
    private void Start()
    {
        _tasks = InitialData.config.tasks;
        textComponent.text = _tasks[_currentTaskInd].text;
    }

    public void TaskIsDone(string taskName)
    {
        if (!_tasks[_currentTaskInd].name.Equals(taskName)) return;

        _currentTaskInd++;
        
        textComponent.text = _tasks[_currentTaskInd].text;
    }
}