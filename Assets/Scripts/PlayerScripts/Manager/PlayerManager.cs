using PlayerScripts.Controllers;
using PlayerScripts.Data.UnityObject;
using PlayerScripts.Data.ValueObject;
using PlayerScripts.Signalable;
using UnityEngine;

namespace PlayerScripts.Manager
{
    public class PlayerManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PlayerController playerController;

        #endregion

        #region Private Variables

        private PlayerData _playerData;
        
        #endregion

        #endregion
        
        private void Awake()
        {
            _playerData = GetPlayerData();
            playerController.PlayerData(_playerData);
        }
        
        #region Event Subscription
        
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            PlayerSignalable.Instance.onEnableScaleMovement += OnEnableScaleMovement;
            PlayerSignalable.Instance.onDeactiveScaleMovement += OnDeactiveScaleMovement;
            PlayerSignalable.Instance.onReset += OnReset;
        }

        private void UnsubscribeEvents()
        {
            PlayerSignalable.Instance.onEnableScaleMovement -= OnEnableScaleMovement;
            PlayerSignalable.Instance.onDeactiveScaleMovement -= OnDeactiveScaleMovement;
            PlayerSignalable.Instance.onReset -= OnReset;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        #endregion

        private PlayerData GetPlayerData()
        {
            return Resources.Load<CD_PlayerData>("Data/CD_PlayerData").PlayerData;
        }

        private void OnEnableScaleMovement()
        {
            playerController.IsReadyToScaleMove = true;
        }

        private void OnDeactiveScaleMovement()
        {
            playerController.IsReadyToScaleMove = false;
        }

        private void OnReset()
        {
            playerController.Reset();
        }
    }
}