using BNG;
using UnityEngine;

public class SnapBehaviour : MonoBehaviour
{
    [SerializeField] private string allowObjectsTag;

    private Rigidbody _rigidbody;
    private GameObject _snappedObject;
    private Transform _previousParent;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals(allowObjectsTag) || _snappedObject) return;
        
        var otherObject = other.transform.parent.gameObject;

        _previousParent = otherObject.transform.parent;
        otherObject.transform.parent = gameObject.transform;

        var confJoint = otherObject.AddComponent<ConfigurableJoint>();

        otherObject.GetComponent<Grabbable>().ParentToHands = false;
        otherObject.transform.localPosition = new Vector3(0.015f, -0.02f, 0.035f);
        otherObject.transform.localRotation = Quaternion.Euler(-90, 60, 40);

        confJoint.xMotion = ConfigurableJointMotion.Locked;
        confJoint.yMotion = ConfigurableJointMotion.Locked;
        confJoint.zMotion = ConfigurableJointMotion.Limited;
        confJoint.angularXMotion = ConfigurableJointMotion.Locked;
        confJoint.angularYMotion = ConfigurableJointMotion.Locked;
        confJoint.angularZMotion = ConfigurableJointMotion.Locked;

        confJoint.linearLimit = new SoftJointLimit {limit = 0.02f};

        confJoint.connectedBody = _rigidbody;

        _snappedObject = otherObject;
    }

    public void UnsnapObject()
    {
        if (!_snappedObject) return;

        Destroy(_snappedObject.GetComponent<ConfigurableJoint>());
        _snappedObject.transform.parent = _previousParent;
        _snappedObject = null;
    }
}