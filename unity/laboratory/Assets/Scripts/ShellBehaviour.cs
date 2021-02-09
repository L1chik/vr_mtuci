using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;

public class ShellBehaviour : MonoBehaviour
{
    public void ShellSnapped()
    {
        var snapZone = transform.parent;
        var cable = snapZone.parent;
        snapZone.GetComponent<SnapZone>().HeldItem = null;
        Destroy(snapZone.gameObject);
        transform.parent = cable;
        var colliders = GetComponentsInChildren<BoxCollider>();
        foreach (var boxCollider in colliders)
        {
            boxCollider.enabled = true;
        }
    }
}