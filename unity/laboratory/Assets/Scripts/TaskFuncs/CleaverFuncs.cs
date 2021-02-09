using System;
using BNG;
using UnityEngine;

namespace TaskFuncs
{
    public class CleaverFuncs : ATaskFuncs
    {
        [SerializeField] private SnapZone snapZone;
        [SerializeField] private GameObject trigger;

        public override bool CheckRequirements()
        {
            if (!snapZone.HeldItem) return true;

            return !snapZone.HeldItem.GetComponentInChildren<HandleCut>();
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
