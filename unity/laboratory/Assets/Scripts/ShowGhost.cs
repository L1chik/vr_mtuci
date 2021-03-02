using System;
using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;
using Enumerable = System.Linq.Enumerable;

public class ShowGhost : MonoBehaviour
{
    [SerializeField] private GameObject ghostObj;

    private GrabbablesInTrigger _grabbable;
    private List<string> onlyAllow;

    private void Start()
    {
        _grabbable = GetComponent<GrabbablesInTrigger>();
        onlyAllow = GetComponent<SnapZone>().OnlyAllowNames;
    }

    private void Update()
    {
        if (_grabbable.NearbyGrabbables.Count > 0 && !ghostObj.activeSelf)
        {
            var e = Enumerable.First(_grabbable.NearbyGrabbables).Value;
            ghostObj.SetActive(onlyAllow.Contains(e.name));
        }
        else if (_grabbable.NearbyGrabbables.Count == 0 && ghostObj.activeSelf)
        {
            ghostObj.SetActive(false);
        }
    }
}