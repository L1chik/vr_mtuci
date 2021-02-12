using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialData : MonoBehaviour
{
    public static Configuration config;
    public static GameObject tooltipPrefab;
    public static GameObject errorTooltipPrefab;
    public static Shader highlightShader;

    [SerializeField] private TextAsset jsonFile;

    private void Awake()
    {
        config = JsonUtility.FromJson<Configuration>(jsonFile.text);
        tooltipPrefab = (GameObject) Resources.Load("ToolTip");
        errorTooltipPrefab = (GameObject) Resources.Load("ErrorToolTip");
        highlightShader = (Shader) Resources.Load("highlight");
    }
}

[Serializable]
public class Configuration
{
    public Task[] tasks;
}

[Serializable]
public class Task
{
    public string name;
    public string helpHint;
    public string errorHint;
    public float[] offset;
}