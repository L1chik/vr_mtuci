using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject objectToCut;
    [SerializeField] private Transform innerObject;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Cutter")) return;

        innerObject.parent = objectToCut.transform.parent;
        objectToCut.AddComponent<Rigidbody>();
        Destroy(gameObject);
    }
}