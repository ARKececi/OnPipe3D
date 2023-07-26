using System.Collections.Generic;
using ShooterScripts.Signalable;
using UnityEngine;

namespace PipesScripts.Controller
{
    public class PipesController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private List<Rigidbody> pipesRigidbodies = new List<Rigidbody>();

        #endregion

        #endregion

        public void Shoot()
        {
            ShooterSignalable.Instance.onShooter?.Invoke(pipesRigidbodies);
        }
    }
}