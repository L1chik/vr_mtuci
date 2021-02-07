using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JointActivator : MonoBehaviour
{
    [SerializeField] private string[] objNames;

    private void OnTriggerEnter(Collider other)
    {
        if (!objNames.Contains(other.name)) return;

        other.GetComponent<ConfigurableJoint>().zMotion = ConfigurableJointMotion.Limited;
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!objNames.Contains(other.name)) return;

        other.GetComponent<ConfigurableJoint>().zMotion = ConfigurableJointMotion.Locked;
    }
}
