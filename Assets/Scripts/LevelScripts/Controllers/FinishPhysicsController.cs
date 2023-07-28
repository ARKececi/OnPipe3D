using System;
using InputScripts.Signalable;
using UnityEngine;

namespace LevelScripts.Controllers
{
    public class FinishPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private FinishController finishController;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                finishController.FinishobjFollow(other.gameObject);
                InputSignalable.Instance.onIsFinishTimeTaken?.Invoke();
            }
        }
    }
}