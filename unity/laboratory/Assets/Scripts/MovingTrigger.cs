using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovingTrigger : MonoBehaviour
{
    [SerializeField] private Vector3 localDirection;
    [SerializeField] private float moveSpeed;

    private void OnTriggerStay(Collider other)
    {
        if (!other.tag.Equals("MoveTrigger")) return;
        Debug.Log("YES");

        transform.parent.localPosition += localDirection * moveSpeed * Time.deltaTime;
    }
}