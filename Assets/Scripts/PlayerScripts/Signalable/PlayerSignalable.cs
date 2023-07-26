using Extention;
using UnityEngine;
using UnityEngine.Events;

namespace PlayerScripts.Signalable
{
    public class PlayerSignalable : MonoSingleton<PlayerSignalable>
    {
        public UnityAction onEnableScaleMovement = delegate { };
        public UnityAction onDeactiveScaleMovement = delegate { };
    }
}