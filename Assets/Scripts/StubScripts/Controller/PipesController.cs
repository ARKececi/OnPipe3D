﻿using System;
using System.Collections.Generic;
using System.Timers;
using Data.ValueObject;
using ShooterScripts.Signalable;
using Signalable;
using StubScripts.PipesScripts.ValueData;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PipesScripts.Controller
{
    public class PipesController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private List<PipeData> pipesRigidbodies = new List<PipeData>();
        [SerializeField] private GameObject look;

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
                VARIABLE.Transform.gameObject.SetActive(true);
                PoolSignalable.Instance.onListPipeAdd?.Invoke(VARIABLE);
            }
        }

        public void OnDisable()
        {
            foreach (var VARIABLE in pipesRigidbodies)
            {
                VARIABLE.Transform.gameObject.SetActive(false);
                PoolSignalable.Instance.onListPipeRemove?.Invoke(VARIABLE);
            }
        }
    }
}