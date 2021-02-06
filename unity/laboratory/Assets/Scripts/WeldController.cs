using System;
using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;

public class WeldController : MonoBehaviour
{
    [SerializeField] private GameObject mainLid;
    [SerializeField] private SnapZone leftCableSnapZone;
    [SerializeField] private SnapZone rightCableSnapZone;

    private JointHelper _lidJointHelper;

    private void Start()
    {
        _lidJointHelper = mainLid.GetComponent<JointHelper>();
    }

    public void StartWelding()
    {
        if (!leftCableSnapZone.HeldItem || !rightCableSnapZone.HeldItem)
        {
            Debug.Log("Не все кабели на месте");
            return;
        }

        LockLid();

        // TODO: Start particles

        StartCoroutine(Welding());
    }

    private IEnumerator Welding()
    {
        // TODO: Connect cable ends
        var weldedCable = new GameObject("WeldedCable");
        weldedCable.transform.position = leftCableSnapZone.transform.parent.TransformPoint(0, 0, 0);

        var leftCable = leftCableSnapZone.HeldItem.transform;
        var rightCable = rightCableSnapZone.HeldItem.transform;

        Destroy(leftCable.GetComponent<Rigidbody>());
        Destroy(rightCable.GetComponent<Rigidbody>());

        leftCableSnapZone.HeldItem = null;
        rightCableSnapZone.HeldItem = null;
        leftCable.SetParent(weldedCable.transform);
        rightCable.SetParent(weldedCable.transform);

        // yield return new WaitForEndOfFrame();
        
        leftCable.transform.rotation = Quaternion.Euler(90, 0, 0);
        leftCable.transform.localPosition = Vector3.zero;
        rightCable.transform.rotation = Quaternion.Euler(90, 0, 180);
        rightCable.transform.localPosition = Vector3.zero;

        yield return new WaitForSeconds(2f);

        // TODO: Stop particles

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