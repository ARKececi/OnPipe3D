using System;
using InputScripts.Signalable;
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
        [SerializeField] private bool isFinishTimeTaken;

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            InputSignalable.Instance.onIsFinishTimeTaken += OnIsFinishTimeTaken;
            InputSignalable.Instance.onReset += OnReset;
        }

        private void UnsubscribeEvents()
        {
            InputSignalable.Instance.onIsFinishTimeTaken -= OnIsFinishTimeTaken;
            InputSignalable.Instance.onReset -= OnReset;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
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

                if (isFinishTimeTaken)
                {
                    LevelSignalable.Instance.onNextLevel?.Invoke();
                    isFinishTimeTaken = false;
                }
            }
            if (Input.GetMouseButtonUp(0)) PlayerSignalable.Instance.onDeactiveScaleMovement?.Invoke();
        }

        private void OnReset()
        {
            isFirstTimeTouchTaken = false;
            isFinishTimeTaken = false;
        }

        private void OnIsFinishTimeTaken()
        {
            isFinishTimeTaken = true;
        }
    }
}