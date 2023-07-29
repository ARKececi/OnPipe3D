using Controllers;
using Controllers.PoolController;
using Enums;
using Signalable;
using StubScripts.PipesScripts.ValueData;
using UnityEngine;

namespace Managers
{
    public class PoolManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PoolController poolController; 
        
        #endregion

        #endregion
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            PoolSignalable.Instance.onListAdd += OnListAdd;
            PoolSignalable.Instance.onListRemove += OnListRemove;
            PoolSignalable.Instance.onListPipeAdd += OnListPipeAdd;
            PoolSignalable.Instance.onPipePlacement += OnPipePlacement;
            PoolSignalable.Instance.onListPipeRemove += OnListPipeRemove;
            PoolSignalable.Instance.onReset += OnReset;
        }

        private void UnsubscribeEvents()
        {
            PoolSignalable.Instance.onListAdd -= OnListAdd;
            PoolSignalable.Instance.onListRemove -= OnListRemove;
            PoolSignalable.Instance.onListPipeAdd -= OnListPipeAdd;
            PoolSignalable.Instance.onPipePlacement -= OnPipePlacement;
            PoolSignalable.Instance.onListPipeRemove -= OnListPipeRemove;
            PoolSignalable.Instance.onReset -= OnReset;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        private void OnListAdd(GameObject poolObj, PoolType poolType)
        {
            poolController.Listadd(poolObj,poolType);
        }

        private GameObject OnListRemove(PoolType poolType)
        {
            return poolController.ListRemove(poolType);
        }

        private void OnListPipeAdd(PipeData pipeData)
        {
            poolController.ListPipeAdd(pipeData);
        }

        private void OnPipePlacement(GameObject pipe)
        {
            poolController.PipePlacement(pipe);
        }

        private void OnListPipeRemove(PipeData pipe)
        {
            poolController.ListPipeRemove(pipe);
        }

        private void OnReset()
        {
            poolController.Reset();
        }
    }
}