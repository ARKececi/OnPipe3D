using System;
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

        [SerializeField] private UIPanelController uıPanelController;

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
            UISignalable.Instance.onScoreSet += OnScoreSet;
            UISignalable.Instance.onLevelSet += OnLevelSet;
            UISignalable.Instance.onPanelAction += OnPanelAction;
            UISignalable.Instance.onPanelReset += OnPanelReset;
        }

        private void UnsubscribeEvents()
        {
            UISignalable.Instance.onGameNext -= OnGameNext;
            UISignalable.Instance.onGameOver -= OnGameOver;
            UISignalable.Instance.onScoreSet -= OnScoreSet;
            UISignalable.Instance.onLevelSet -= OnLevelSet;
            UISignalable.Instance.onPanelAction -= OnPanelAction;
            UISignalable.Instance.onPanelReset -= OnPanelReset;
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
            OnPanelReset(UIPanel.FinishPanel);
        }

        private void OnGameNext()
        {
            PoolSignalable.Instance.onReset?.Invoke();
            LevelSignalable.Instance.onNextLevel?.Invoke();
            PlayerSignalable.Instance.onReset?.Invoke();
            CameraSignalable.Instance.onReset?.Invoke();
            InputSignalable.Instance.onReset?.Invoke();
            OnPanelReset(UIPanel.FinishPanel);
        }
        

        private void OnPanelReset(UIPanel panel)
        {
            uıPanelController.PanelsReset(panel);
        }

        private void OnScoreSet(int score)
        {
            uıPanelController.ScoreText(score);
        }

        private void OnLevelSet(int level)
        {
            uıPanelController.LevelSet(level);
        }

        private void OnPanelAction(UIPanel panel)
        {
            uıPanelController.PanelAction(panel);
        }
    }
}