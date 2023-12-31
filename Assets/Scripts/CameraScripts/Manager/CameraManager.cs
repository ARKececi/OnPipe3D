using System;
using CameraScripts.Signalable;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

namespace CameraScripts.CameraManager
{
    public class CameraManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private CinemachineStateDrivenCamera vmStateCamera;
        [SerializeField] private CinemachineVirtualCamera vmCamera;
        [SerializeField] private Animator animator;
        [SerializeField] private float amplitudeGain;
        [SerializeField] private float timer;
        [SerializeField] private GameObject player;

        #endregion

        #region Private Variables

        private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;
        private Enum.CameraState _cameraState;
        private Transform _player;
        private float _timer;
        private bool _trigger;
        
        #endregion

        #endregion

        private void Awake()
        {
            cinemachineBasicMultiChannelPerlin = vmCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        #region Event Subscription
        
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CameraSignalable.Instance.onSetCamera += OnSetCamera;
            CameraSignalable.Instance.onShakeCamera += OnShakeCamera;
            CameraSignalable.Instance.onReset += OnReset;
        }

        private void UnsubscribeEvents()
        {
            CameraSignalable.Instance.onSetCamera -= OnSetCamera;
            CameraSignalable.Instance.onShakeCamera -= OnShakeCamera;
            CameraSignalable.Instance.onReset -= OnReset;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        #endregion
        
        private void OnPlayEnter()
        {
            switch (_cameraState)
            {
                case Enum.CameraState.Main:
                    _cameraState = Enum.CameraState.Main; 
                    animator.SetTrigger(_cameraState.ToString());
                    break;
            }
        }
        
        private void OnSetCamera(GameObject player)
        {
            _player = player.transform;
            vmCamera.Follow = _player;
        }

        private void ShakeTimer()
        {
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
        }

        private void OnShakeCamera()
        {
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = amplitudeGain;
            DOVirtual.DelayedCall(timer, () => ShakeTimer());
        }

        private void OnReset()
        {
            OnSetCamera(player);
        }
    }
}
