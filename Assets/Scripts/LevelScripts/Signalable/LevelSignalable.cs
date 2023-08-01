using System;
using Extention;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace LevelScripts.Signalable
{
    public class LevelSignalable : MonoSingleton<LevelSignalable>
    {
        public UnityAction onNextRod = delegate { };
        public UnityAction onGameStart = delegate { };
        public UnityAction onNextLevel = delegate { };
        public UnityAction onReset = delegate { };
        public Func<int> onSaveLevel = delegate { return 0;};
    }
}