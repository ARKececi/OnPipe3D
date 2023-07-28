using System;
using CameraScripts.Signalable;
using PlayerScripts.Data.ValueObject;
using UnityEngine;

namespace PlayerScripts.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public bool IsReadyToScaleMove;

        #endregion

        #region Serialized Variables

        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private Transform playerTransform;

        #endregion

        private PlayerData _playerData;
        private float _timer;
        private bool _gameOver;
        private bool _reduceBoundary;
        private Vector3 _largeBoundary;
        private Vector3 _startPosition;

        #endregion
        public void EnableScaleBoundary(){_reduceBoundary = true;}
        public void DisableScaleBoundary(){_reduceBoundary = false;}
        public void EnableGameOver(){ _gameOver = true;}

        public void PlayerData(PlayerData playerData)
        {
            _playerData = playerData;
        }
        
        private void Start()
        {
            _largeBoundary = playerTransform.localScale;
            _startPosition = playerTransform.position;
            _timer = _playerData.ScaleTimer;
        }

        private void ScaleTimer()
        {
            if (_gameOver) return;
            if (IsReadyToScaleMove)
            {
                if (!_reduceBoundary)
                {
                    while (_timer < 0)
                    {
                        ReduceScale();
                        _timer = _playerData.ScaleTimer;
                    }
                }
            }
            else if (_largeBoundary != playerTransform.localScale)
            {
                while (_timer < 0)
                {
                    EnlargeScale();
                    _timer = _playerData.ScaleTimer;
                }
            }
            _timer -= UnityEngine.Time.deltaTime;
        }
        
        private void ReduceScale() { playerTransform.localScale = new Vector3(playerTransform.localScale.x - _playerData.Amount, playerTransform.localScale.y, playerTransform.localScale.z - _playerData.Amount);}
        private void EnlargeScale() { playerTransform.localScale = new Vector3(playerTransform.localScale.x + _playerData.Amount, playerTransform.localScale.y, playerTransform.localScale.z + _playerData.Amount);}

        private void FixedUpdate()
        {
            Move();
            ScaleTimer();
        }

        private void Move()
        {
            rigidbody.velocity = _gameOver == false ? new Vector3(0, _playerData.Speed, 0) : Vector3.zero;
        }

        public void Reset()
        {
            _gameOver = false;
            IsReadyToScaleMove = false;
            playerTransform.localScale = _largeBoundary;
            playerTransform.position = _startPosition;
        }
    }
}