using BNG;
using UnityEngine;

public class StripperBehaviour : MonoBehaviour
{
    private Animator _animator;
    private InputBridge _input;
    private Grabbable _grabbable;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _input = InputBridge.Instance;
        _grabbable = GetComponent<Grabbable>();
    }

    private void Update()
    {
        _animator.SetBool("Trigger", _grabbable.BeingHeld && (_input.LeftTriggerUp || _input.RightTriggerUp));
    }
}