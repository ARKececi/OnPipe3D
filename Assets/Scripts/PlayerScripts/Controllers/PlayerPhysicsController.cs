﻿using System;
using CameraScripts.Signalable;
using UnityEngine;

namespace PlayerScripts.Controllers
{
    public class PlayerPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Varibles

        [SerializeField] private PlayerController playerController;

        #endregion

        #endregion

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Plane"))
            {
                playerController.EnableScaleBoundary();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("GameOver"))
            {
                playerController.EnableGameOver();
                CameraSignalable.Instance.onShakeCamera?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Plane"))
            {
                playerController.DisableScaleBoundary();
            }
        }
    }
}