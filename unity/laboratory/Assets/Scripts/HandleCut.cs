using System;
using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;
using UnityEngine.Events;

public class HandleCut : MonoBehaviour
{
    public UnityEvent onFinishCut;

    private GameObject objectToCut;
    private bool isStripperActive;

    private void Start()
    {
        objectToCut = transform.parent.gameObject;
        var stripperEvents = GameObject.FindGameObjectWithTag("Stripper").GetComponent<GrabbableUnityEvents>();
        Debug.Log(stripperEvents);

        stripperEvents.onTriggerDown.AddListener(Enable);
        stripperEvents.onTriggerUp.AddListener(Disable);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.tag.Equals("Cutter") || !isStripperActive) return;

        var localPosition = transform.parent.localPosition;
        localPosition = Vector3.MoveTowards(localPosition,
            localPosition + new Vector3(0, 0.5f, 0),
            0.1f * Time.deltaTime);
        transform.parent.localPosition = localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Finish")) return;

        objectToCut.transform.parent = null;
        objectToCut.AddComponent<Rigidbody>();

        onFinishCut?.Invoke();

        Destroy(gameObject);
    }

    private void Enable()
    {
        isStripperActive = true;
    }

    private void Disable()
    {
        isStripperActive = false;
    }
}