using System;
using Enums;
using Signalable;
using UnityEngine;

namespace DestroyScripts
{
    public class DestroyPhysicsController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ball"))
            {
                PoolSignalable.Instance.onPipePlacement?.Invoke(other.gameObject);
            }

            if (other.CompareTag("Stub"))
            {
                PoolSignalable.Instance.onListAdd?.Invoke(other.gameObject,PoolType.Stup);
            }
        }
    }
}