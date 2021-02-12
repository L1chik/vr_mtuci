using BNG;
using UnityEngine;

namespace TaskFuncs
{
    public class SnapFuncs : ATaskFuncs
    {
        [SerializeField] private SnapZone leftSnapZone;
        [SerializeField] private SnapZone rightSnapZone;

        private SnapZone _mainSnapZone;

        public override bool CheckRequirements()
        {
            if (leftSnapZone.HeldItem && rightSnapZone.HeldItem)
            {
                if (leftSnapZone.HeldItem.GetComponentInChildren<HandleCleaverCut>(true))
                {
                    _mainSnapZone = leftSnapZone;
                    return false;
                }

                if (!rightSnapZone.HeldItem.GetComponentInChildren<HandleCleaverCut>(true)) return true;
                _mainSnapZone = rightSnapZone;

                return false;
            }

            _mainSnapZone = leftSnapZone.HeldItem ? leftSnapZone : rightSnapZone;
            if (!_mainSnapZone.HeldItem) return true;

            return !_mainSnapZone.HeldItem.GetComponentInChildren<HandleCleaverCut>(true);
        }

        public override void HandleInvalid()
        {
            _mainSnapZone.HeldItem.transform.parent = null;
            _mainSnapZone.HeldItem.transform.GetComponent<Grabbable>().enabled = true;
            _mainSnapZone.GrabEquipped(null);
            _mainSnapZone.HeldItem = null;
            _mainSnapZone.HeldItem = null;
        }
    }
}