using System;
using BNG;
using UnityEngine;

namespace TaskFuncs
{
    public class CleaverFuncs : ATaskFuncs
    {
        [SerializeField] private SnapZone snapZone;
        [SerializeField] private Transform shell;
        [SerializeField] private GameObject trigger;

        public override bool CheckRequirements()
        {
            if (!snapZone.HeldItem) return true;

            return snapZone.HeldItem.GetComponentInChildren<HandleCut>() == null && shell.parent.name.Equals("Cable");
        }

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