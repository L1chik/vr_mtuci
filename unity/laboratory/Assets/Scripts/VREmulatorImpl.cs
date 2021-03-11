using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BNG
{

    [RequireComponent(typeof(BNGPlayerController))]
    public class VREmulatorImpl : VREmulator
    {
        void Reset()
        {
            Debug.Log("Emulator has been set");
        }
    }
}
