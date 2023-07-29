using Extention;
using UnityEngine;
using UnityEngine.Events;

namespace InputScripts.Signalable
{
    public class InputSignalable : MonoSingleton<InputSignalable>
    {
        public UnityAction onIsFinishTimeTaken = delegate { };
        public UnityAction onReset = delegate { };
        public UnityAction onGameOver = delegate { };
        public UnityAction onfinish = delegate { };
        
    }
}