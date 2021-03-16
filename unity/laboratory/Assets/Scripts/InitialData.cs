using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialData : MonoBehaviour
{
    public static Configuration config;
    public static GameObject tooltipPrefab;
    public static GameObject errorTooltipPrefab;
    public static Material highlightMaterial;

    [SerializeField] private TextAsset jsonFile;

    private void Awake()
    {
        config = JsonUtility.FromJson<Configuration>(jsonFile.text);
        Messenger<Task[]>.Broadcast(MessageEvent.RESET_TASKS, config.tasks);
        tooltipPrefab = (GameObject) Resources.Load("ToolTip");
        errorTooltipPrefab = (GameObject) Resources.Load("ErrorToolTip");
        highlightMaterial = (Material) Resources.Load("highlights");
    }
}

[Serializable]
public class Configuration
{
    public Task[] tasks;
}
