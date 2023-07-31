using Extention;
using UISicripts.Enum;
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
    }
}