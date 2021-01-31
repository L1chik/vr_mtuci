using System;
using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;

public class WeldController : MonoBehaviour
{
    [SerializeField] private GameObject mainLid;
    [SerializeField] private bool isLeftCableSnapped;
    [SerializeField] private bool isRightCableSnapped;

    private JointHelper _lidJointHelper;

    private void Start()
    {
        _lidJointHelper = mainLid.GetComponent<JointHelper>();
    }

    public void StartWelding()
    {
        Debug.Log("???");
        if (!isLeftCableSnapped || !isRightCableSnapped)
        {
            Debug.Log("Не все кабели на месте");
            return;
        }
        Debug.Log("??fewfew?");

        LockLid();

        // TODO: Start particles

        StartCoroutine(Welding());
    }

    private IEnumerator Welding()
    {
        yield return new WaitForSeconds(2f);

        // TODO: Stop particles

        // TODO: Connect cable ends

        UnlockLid();

        Debug.Log("Done");
    }

    private void LockLid()
    {
        _lidJointHelper.LockXRotation = _lidJointHelper.LockYRotation = _lidJointHelper.LockZRotation = true;
    }

    private void UnlockLid()
    {
        _lidJointHelper.LockXRotation = _lidJointHelper.LockYRotation = _lidJointHelper.LockZRotation = false;
    }
}