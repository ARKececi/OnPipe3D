using System.Collections.Generic;
using Data.ValueObject;
using ShooterScripts.Controller;
using ShooterScripts.Signalable;
using StubScripts.PipesScripts.ValueData;
using UnityEngine;

namespace ShooterScripts.Manager
{
    public class ShooterManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private ShooterController shooterController;

        #endregion

        #endregion
        
        #region Event Subscription
        
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            ShooterSignalable.Instance.onShooter += OnShooter;
        }

        private void UnsubscribeEvents()
        {
            ShooterSignalable.Instance.onShooter -= OnShooter;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        #endregion

        private void OnShooter(List<PipeData> pipes)
        {
            shooterController.Shooter(pipes);
        }
    }
}