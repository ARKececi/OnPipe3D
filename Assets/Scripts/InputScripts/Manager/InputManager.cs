using System;
using InputScripts.Signalable;
using LevelScripts.Signalable;
using PlayerScripts.Signalable;
using UISicripts.Enum;
using UISicripts.Signalable;
using UnityEngine;

namespace InputScripts.InputManager
{
    public class InputManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private bool isFirstTimeTouchTaken, isFinishTimeTaken, gameOver, finish;

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
            InputSignalable.Instance.onGameOver += OnGameOver;
            InputSignalable.Instance.onfinish += Onfinish;
        }

        private void UnsubscribeEvents()
        {
            InputSignalable.Instance.onIsFinishTimeTaken -= OnIsFinishTimeTaken;
            InputSignalable.Instance.onReset -= OnReset;
            InputSignalable.Instance.onGameOver -= OnGameOver;
            InputSignalable.Instance.onfinish -= Onfinish;
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
                    UISignalable.Instance.onPanelAction.Invoke(UIPanel.ScorePanel);
                    UISignalable.Instance.onPanelReset?.Invoke(UIPanel.FinishPanel);
                    isFirstTimeTouchTaken = true;
                }
                

                if (isFinishTimeTaken)
                {
                    UISignalable.Instance.onGameNext?.Invoke();
                    isFinishTimeTaken = false;
                }

                if (gameOver)
                {
                    UISignalable.Instance.onGameOver?.Invoke();
                    OnReset();
                    gameOver = false;
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

        private void Onfinish()
        {
            finish = true;
        }

        private void OnGameOver()
        {
            gameOver = true;
        }
    }
}