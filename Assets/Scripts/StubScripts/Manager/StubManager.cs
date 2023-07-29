using System;
using System.Collections.Generic;
using PipesScripts.Controller;
using UnityEngine;

namespace StubScripts.Manager
{
    public class StubManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private List<GameObject> pipes;

        #endregion

        #endregion

        private void OnEnable()
        {
            foreach (var VARIABLE in pipes)
            {
                VARIABLE.SetActive(true);
            }
        }

        private void OnDisable()
        {
            foreach (var VARIABLE in pipes)
            {
                VARIABLE.SetActive(false);
            }
        }
    }
}