using System;
using System.Collections.Generic;
using Enums;
using Signalable;
using UnityEngine;

namespace RodScripts.Manager
{
    public class RodManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private List<GameObject> stupPosition;

        #endregion

        #region Private Variables

        private bool _notFirstEnable;

        #endregion

        #endregion
        private void OnEnable()
        {
            if (_notFirstEnable) return;
            foreach (var VARIABLE in stupPosition)
            {
               GameObject stup = PoolSignalable.Instance.onListRemove?.Invoke(PoolType.Stup);
               stup.transform.position = VARIABLE.transform.position;
            }
            _notFirstEnable = true;
        }
    }
}