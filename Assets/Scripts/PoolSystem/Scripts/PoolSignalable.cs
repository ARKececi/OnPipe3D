using System;
using Enums;
using Extention;
using StubScripts.PipesScripts.ValueData;
using UnityEngine;
using UnityEngine.Events;

namespace Signalable
{
    public class PoolSignalable : MonoSingleton<PoolSignalable>
    {
        public UnityAction<GameObject,PoolType> onListAdd = delegate {  };
        public Func<PoolType,GameObject> onListRemove = delegate { return null;};
        public UnityAction<PipeData> onListPipeAdd = delegate { };
        public UnityAction<GameObject> onPipePlacement = delegate { };
    }
}