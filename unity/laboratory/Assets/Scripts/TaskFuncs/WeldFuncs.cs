using System;
using BNG;
using UnityEngine;

namespace TaskFuncs
{
    public class WeldFuncs : ATaskFuncs
    {
        [SerializeField] private GameObject shell;

        public override void HandleTaskIsDone(string taskName)
        {
            var checkShellPos = shell.GetComponentInChildren<CheckShellPos>(true);
            checkShellPos.enabled = true;
        }
    }
}