using Extention;
using SaveScripts.Struck;
using UnityEngine;
using UnityEngine.Events;

namespace SaveScripts.Signalable
{
    public class SaveSignalable : MonoSingleton<SaveSignalable>
    {
        public UnityAction onSave = delegate { };
    }
}