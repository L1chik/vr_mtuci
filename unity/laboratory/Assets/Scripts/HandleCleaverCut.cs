using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HandleCleaverCut : MonoBehaviour
{
    private GameObject objectToCut;

    private void Start()
    {
        objectToCut = transform.parent.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Cleaver")) return;

        objectToCut.transform.parent = null;
        objectToCut.AddComponent<Rigidbody>();

        Destroy(gameObject);
    }
}