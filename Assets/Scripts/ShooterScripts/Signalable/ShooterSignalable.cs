using System.Collections.Generic;
using Extention;
using UnityEngine;
using UnityEngine.Events;

namespace ShooterScripts.Signalable
{
    public class ShooterSignalable : MonoSingleton<ShooterSignalable>
    {
        public UnityAction<List<Rigidbody>> onShooter = delegate { };
    }
}