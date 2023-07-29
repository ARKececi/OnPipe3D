using CameraScripts.Signalable;
using DG.Tweening;
using InputScripts.Signalable;
using LevelScripts.Signalable;
using PlayerScripts.Signalable;
using Signalable;
using TMPro;
using UISicripts.Controller;
using UISicripts.Enum;
using UISicripts.Signalable;
using UnityEngine;
using UnityEngine.UI;

namespace UISicripts.Manager
{
    public class UIManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private Image FinishPanel;

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            UISignalable.Instance.onGameNext += OnGameNext;
            UISignalable.Instance.onGameOver += OnGameOver;
        }

        private void UnsubscribeEvents()
        {
            UISignalable.Instance.onGameNext -= OnGameNext;
            UISignalable.Instance.onGameOver -= OnGameOver;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        #endregion

        private void OnGameOver()
        {
            PoolSignalable.Instance.onReset?.Invoke();
            LevelSignalable.Instance.onReset?.Invoke();
            PlayerSignalable.Instance.onReset?.Invoke();
            CameraSignalable.Instance.onReset?.Invoke();
            InputSignalable.Instance.onReset?.Invoke();
        }

        private void OnGameNext()
        {
            PoolSignalable.Instance.onReset?.Invoke();
            LevelSignalable.Instance.onNextLevel?.Invoke();
            PlayerSignalable.Instance.onReset?.Invoke();
            CameraSignalable.Instance.onReset?.Invoke();
            InputSignalable.Instance.onReset?.Invoke();
        }

        private void PanelAlpha()
        {
            
        }
    }
}