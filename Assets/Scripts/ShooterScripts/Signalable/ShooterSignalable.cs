using System.Collections.Generic;
using Extention;
using StubScripts.PipesScripts.ValueData;
using UnityEngine;
using UnityEngine.Events;

namespace ShooterScripts.Signalable
{
    public class ShooterSignalable : MonoSingleton<ShooterSignalable>
    {
        public UnityAction<List<PipeData>> onShooter = delegate { };
    }
}