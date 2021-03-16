using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Task
{
    public int priority;
    public string name;
    public string helpHint;
    public string errorHint;
    public float[] offset;
}