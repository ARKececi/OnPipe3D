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
                Vector3 pipe = pipeData.Rigidbody.transform.position;
                pipeData.Rigidbody.useGravity = true;
                pipeData.Rigidbody.AddForce(new Vector3(pipe.x * force,0,pipe.z), ForceMode.Impulse);
                pipeData.Rigidbody.AddForce(pipeData.Rigidbody.transform.up * force, ForceMode.Impulse);
            }
        }
    }
}