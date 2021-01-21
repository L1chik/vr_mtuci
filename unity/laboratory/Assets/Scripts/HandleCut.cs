using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCut : MonoBehaviour
{
    private GameObject _objectToCut;
    private Transform _cutterTransform;
    private float _previousPosY;

    private void Start()
    {
        _objectToCut = transform.parent.gameObject;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.tag.Equals("Cutter")) return;

        transform.parent.localPosition = Vector3.MoveTowards(transform.parent.localPosition,
            transform.parent.localPosition + new Vector3(0, 0.5f, 0),
            0.1f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Finish")) return;

        _objectToCut.GetComponent<Rigidbody>().isKinematic = false;
        Destroy(_objectToCut.GetComponent<ConfigurableJoint>());
        
        Destroy(gameObject);
    }
}