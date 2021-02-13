using BNG;
using UnityEngine;

namespace TaskFuncs
{
    public class ToolBoxFuncs : ATaskFuncs
    {
        private GrabbableUnityEvents _stripperGrabEvents;
        
        private void Start()
        {
            _stripperGrabEvents = GameObject.FindWithTag("Stripper").GetComponent<GrabbableUnityEvents>();
        }

        public override void HandleTaskIsDone(string taskName)
        {
            _stripperGrabEvents.onGrab.RemoveAllListeners();
        }
    }
}
