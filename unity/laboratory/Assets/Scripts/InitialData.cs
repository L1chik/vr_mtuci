using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialData : MonoBehaviour
{
    public static Configuration config;

    [SerializeField] private TextAsset jsonFile;

    private void Awake()
    {
        config = JsonUtility.FromJson<Configuration>(jsonFile.text);
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
    public string text;
}