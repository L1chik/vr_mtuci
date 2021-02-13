using System;
using BNG;
using UnityEngine;

namespace TaskFuncs
{
    public class HeaterFuncs : ATaskFuncs
    {
        [SerializeField] private SnapZone snapZone;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip clip;

        public override bool CheckRequirements()
        {
            return snapZone.HeldItem;
        }

        public override void HandleTaskIsDone(string taskName)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}