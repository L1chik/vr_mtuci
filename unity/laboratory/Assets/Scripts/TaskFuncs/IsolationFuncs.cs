using System;
using BNG;
using UnityEngine;

namespace TaskFuncs
{
    public class IsolationFuncs : ATaskFuncs
    {
        [SerializeField] private Transform shell;
        [SerializeField] private GameObject trigger;
        

        public override void HandleIsChecked()
        {
            trigger.SetActive(true);
        }

        public override void HandleInvalid()
        {
            trigger.SetActive(false);
        }
    }
}
