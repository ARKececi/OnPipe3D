using System;
using PlayerScripts.Signalable;
using UnityEngine;

namespace InputScripts.InputManager
{
    public class InputManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private bool isReadyForTouch, isFirstTimeTouchTaken;

        #endregion

        #endregion
        private void Update()
        {
            if (!isReadyForTouch) return;
            if (Input.GetMouseButtonDown(0)) PlayerSignalable.Instance.onEnableScaleMovement?.Invoke();
            if (Input.GetMouseButtonUp(0)) PlayerSignalable.Instance.onDeactiveScaleMovement?.Invoke();
        }
    }
}