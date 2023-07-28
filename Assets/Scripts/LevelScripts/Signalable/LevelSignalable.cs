using Extention;
using UnityEngine;
using UnityEngine.Events;

namespace LevelScripts.Signalable
{
    public class LevelSignalable : MonoSingleton<LevelSignalable>
    {
        public UnityAction onNextRod = delegate { };
        public UnityAction onGameStart = delegate { };
        public UnityAction onNextLevel = delegate { };
    }
}