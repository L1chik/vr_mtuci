using BNG;
using UnityEngine;

namespace TaskFuncs
{
    public class SnapFuncs : ATaskFuncs
    {
        public SnapZone leftSnapZone;
        public SnapZone rightSnapZone;

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

        public override void HandleTaskIsDone(string taskName)
        {
            if (!taskName.Equals("SnapCable")) return;

            var taskLogic = _mainSnapZone.transform.parent.gameObject.AddComponent<TaskLogic>();
            taskLogic.taskName = "SnapCable2";

            var snapFuncs = _mainSnapZone.gameObject.AddComponent<SnapFuncs>();
            snapFuncs.leftSnapZone = leftSnapZone;
            snapFuncs.rightSnapZone = rightSnapZone;

            if (_mainSnapZone.name.Equals("Left"))
            {
                rightSnapZone.OnSnapEvent.AddListener((Grabbable g) => taskLogic.TaskIsDone());
            }
            else
            {
                leftSnapZone.OnSnapEvent.AddListener((Grabbable g) => taskLogic.TaskIsDone());
            }
        }
    }
}