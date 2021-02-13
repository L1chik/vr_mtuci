using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BNG;
using UnityEngine;

public class WeldController : MonoBehaviour
{
    [SerializeField] private GameObject mainLid;
    [SerializeField] private SnapZone leftCableSnapZone;
    [SerializeField] private SnapZone rightCableSnapZone;
    [SerializeField] private Vector3 leftGrabPointPositionOffset;
    [SerializeField] private Vector3 leftGrabPointRotationOffset;
    [SerializeField] private Vector3 rightGrabPointPositionOffset;
    [SerializeField] private Vector3 rightGrabPointRotationOffset;

    private JointHelper _lidJointHelper;
    private GameObject[] _cables = new GameObject[2];
    private TaskLogic _taskLogic;
    private ParticleSystem _particle;

    private void Start()
    {
        _lidJointHelper = mainLid.GetComponent<JointHelper>();
        _taskLogic = GetComponent<TaskLogic>();
        _particle = GetComponentInChildren<ParticleSystem>();
    }

    public void StartWelding()
    {
        if (!leftCableSnapZone.HeldItem || !rightCableSnapZone.HeldItem)
        {
            Debug.Log("Не все кабели на месте");
            return;
        }

        _cables[0] = leftCableSnapZone.HeldItem.gameObject;
        _cables[1] = rightCableSnapZone.HeldItem.gameObject;

        LockLid();

        _particle.Play();

        StartCoroutine(Welding());
    }

    private IEnumerator Welding()
    {
        var weldedCable = new GameObject("WeldedCable");
        weldedCable.transform.position = leftCableSnapZone.transform.parent.TransformPoint(0, 0, 0);

        var leftCable = _cables[0];
        var rightCable = _cables[1];

        leftCableSnapZone.HeldItem = rightCableSnapZone.HeldItem = null;
        leftCable.transform.parent = rightCable.transform.parent = weldedCable.transform;

        leftCable.transform.localPosition = rightCable.transform.localPosition = Vector3.zero;
        leftCable.transform.rotation = Quaternion.Euler(90, 0, 0);
        rightCable.transform.rotation = Quaternion.Euler(90, 0, 180);

        weldedCable.AddComponent<Rigidbody>();
        var weldedCableGrabbable = weldedCable.AddComponent<Grabbable>();
        weldedCableGrabbable.GrabPhysics = GrabPhysics.Kinematic;
        
        foreach (var cable in _cables)
        {
            Destroy(cable.GetComponent<Rigidbody>());
            Destroy(cable.GetComponent<GrabbableUnityEvents>());
            Destroy(cable.GetComponent<Grabbable>());
            Destroy(cable.GetComponent<SnapZoneOffset>());

            cable.AddComponent<GrabbableChild>().ParentGrabbable = weldedCableGrabbable;
        }

        var leftGrabPointObj = new GameObject("LeftGrab");
        var rightGrabPointObj = new GameObject("RightGrab");
        leftGrabPointObj.transform.parent = rightGrabPointObj.transform.parent = weldedCable.transform;
        leftGrabPointObj.transform.localPosition = leftGrabPointPositionOffset;
        leftGrabPointObj.transform.rotation = Quaternion.Euler(leftGrabPointRotationOffset);
        rightGrabPointObj.transform.localPosition = rightGrabPointPositionOffset;
        rightGrabPointObj.transform.rotation = Quaternion.Euler(rightGrabPointRotationOffset);

        var leftGrabPoint = leftGrabPointObj.AddComponent<GrabPoint>();
        leftGrabPoint.RightHandIsValid = false;
        var rightGrabPoint = rightGrabPointObj.AddComponent<GrabPoint>();
        rightGrabPoint.LeftHandIsValid = false;
        leftGrabPoint.HandPose = rightGrabPoint.HandPose = HandPoseId.FingersGrip;

        weldedCableGrabbable.GrabPoints = new List<Transform> {leftGrabPointObj.transform, rightGrabPointObj.transform};

        yield return new WaitForSeconds(2f);

        _particle.Stop();

        UnlockLid();

        _taskLogic.TaskIsDone(false);
    }

    private void LockLid()
    {
        _lidJointHelper.LockZRotation = true;
    }

    private void UnlockLid()
    {
        _lidJointHelper.LockZRotation = false;
    }
}