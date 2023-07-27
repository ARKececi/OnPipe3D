using System.Collections.Generic;
using Data.ValueObject;
using StubScripts.PipesScripts.ValueData;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShooterScripts.Controller
{
    public class ShooterController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private float force;

        #endregion

        #endregion
        
        public void Shooter(List<PipeData> pipes)
        {
            foreach (var pipeData in pipes)
            {
                pipeData.Rigidbody.useGravity = true;
                pipeData.Rigidbody.AddForce(pipeData.Rigidbody.transform.right * force, ForceMode.Impulse);
                pipeData.Rigidbody.AddForce(pipeData.Rigidbody.transform.up * force, ForceMode.Impulse);
            }
        }
    }
}