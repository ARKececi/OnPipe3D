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
            UISignalable.Instance.onLevelComplated += OnLevelComplated;
            UISignalable.Instance.onBestScore += OnBestScore;
        }

        private void UnsubscribeEvents()
        {
            UISignalable.Instance.onGameNext -= OnGameNext;
            UISignalable.Instance.onGameOver -= OnGameOver;
            UISignalable.Instance.onScoreSet -= OnScoreSet;
            UISignalable.Instance.onLevelSet -= OnLevelSet;
            UISignalable.Instance.onPanelAction -= OnPanelAction;
            UISignalable.Instance.onPanelReset -= OnPanelReset;
            UISignalable.Instance.onLevelComplated -= OnLevelComplated;
            UISignalable.Instance.onBestScore -= OnBestScore;
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
            OnPanelAction(UIPanel.ScorePanel);
            OnPanelAction(UIPanel.StartPanel);
            OnScoreReset();
        }

        private void OnGameNext()
        {
            PoolSignalable.Instance.onReset?.Invoke();
            LevelSignalable.Instance.onNextLevel?.Invoke();
            PlayerSignalable.Instance.onReset?.Invoke();
            CameraSignalable.Instance.onReset?.Invoke();
            InputSignalable.Instance.onReset?.Invoke();
            OnPanelReset(UIPanel.FinishPanel);
            OnPanelAction(UIPanel.ScorePanel);
            OnPanelAction(UIPanel.StartPanel);
        }
        

        private void OnPanelReset(UIPanel panel)
        {
            uıPanelController.PanelsReset(panel);
        }

        private void OnScoreSet(int score)
        {
            uıPanelController.ScoreSet(score);
        }

        private void OnLevelSet(int level)
        {
            uıPanelController.LevelSet(level);
        }

        private void OnPanelAction(UIPanel panel)
        {
            uıPanelController.PanelAction(panel);
        }

        private void OnLevelComplated(bool final)
        {
            uıPanelController.LevelComplated(final);
        }

        private void OnScoreReset()
        {
            uıPanelController.ScoreReset();
        }

        private int OnBestScore()
        {
            return uıPanelController.BestScore();
        }
    }
}