using System;
using System.Collections.Generic;
using System.Timers;
using Data.ValueObject;
using ShooterScripts.Signalable;
using Signalable;
using StubScripts.PipesScripts.ValueData;
using UnityEngine;

namespace PipesScripts.Controller
{
    public class PipesController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private List<PipeData> pipesRigidbodies = new List<PipeData>();

        #endregion

        #region Private Variables
        
        private float _timer;
        
        #endregion

        #endregion

        public void Shoot()
        {
            ShooterSignalable.Instance.onShooter?.Invoke(pipesRigidbodies);
        }

        public void OnEnable()
        {
            foreach (var VARIABLE in pipesRigidbodies)
            {
                PoolSignalable.Instance.onListPipeAdd?.Invoke(VARIABLE);
            }
        }
    }
}