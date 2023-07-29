using System;
using PipesScripts.Controller;
using UnityEngine;

namespace Scripts
{
    public class PipesPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PipesController pipesController;
        
        #endregion

        #endregion
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                pipesController.Shoot();
            }
        }
    }
}