using Extention;
using UnityEngine;
using UnityEngine.Events;

namespace CameraScripts.Signalable
{
    public class CameraSignalable : MonoSingleton<CameraSignalable>
    {
       public UnityAction<GameObject> onSetCamera = delegate { };
       public UnityAction onShakeCamera = delegate { };
       public UnityAction onReset = delegate { };
    }
}