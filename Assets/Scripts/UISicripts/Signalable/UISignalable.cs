using Extention;
using UnityEngine;
using UnityEngine.Events;

namespace UISicripts.Signalable
{
    public class UISignalable : MonoSingleton<UISignalable>
    {
        public UnityAction onGameNext = delegate { };
        public UnityAction onGameOver = delegate { };
    }
}