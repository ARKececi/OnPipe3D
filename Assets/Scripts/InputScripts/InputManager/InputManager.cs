using System;
using LevelScripts.Signalable;
using PlayerScripts.Signalable;
using UnityEngine;

namespace InputScripts.InputManager
{
    public class InputManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private bool isFirstTimeTouchTaken;

        #endregion

        #endregion
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlayerSignalable.Instance.onEnableScaleMovement?.Invoke();
                if (isFirstTimeTouchTaken != true)
                {
                    LevelSignalable.Instance.onGameStart?.Invoke();
                    isFirstTimeTouchTaken = true;
                }
            }
            if (Input.GetMouseButtonUp(0)) PlayerSignalable.Instance.onDeactiveScaleMovement?.Invoke();
        }

        private void Reset()
        {
            isFirstTimeTouchTaken = false;
        }
    }
}