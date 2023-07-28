using DG.Tweening;
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

        [SerializeField] private Image FinishPanel;

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {

        }

        private void UnsubscribeEvents()
        {

        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        #endregion

        private void FinishPanelAlpha()
        {
            
        }
    }
}