using System;
using Extention;
using UISicripts.Enum;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace UISicripts.Signalable
{
    public class UISignalable : MonoSingleton<UISignalable>
    {
        public UnityAction onGameNext = delegate { };
        public UnityAction onGameOver = delegate { };
        public UnityAction<int> onScoreSet = delegate { };
        public UnityAction<int> onLevelSet = delegate { };
        public UnityAction<UIPanel> onPanelAction = delegate { };
        public UnityAction<UIPanel> onPanelReset = delegate { };
        public UnityAction<bool> onLevelComplated = delegate { };
        public Func<int> onBestScore = delegate { return 0; };
    }
}