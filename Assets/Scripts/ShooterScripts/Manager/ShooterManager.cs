using System.Collections.Generic;
using ShooterScripts.Controller;
using ShooterScripts.Signalable;
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

        private void OnShooter(List<Rigidbody> pipes)
        {
            shooterController.Shooter(pipes);
        }
    }
}