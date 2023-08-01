using System.Collections.Generic;
using Data.ValueObject;
using DG.Tweening;
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
                var rand = new Vector3(Random.Range(180, -180), Random.Range(180, 180), Random.Range(180, -180));
                Vector3 pipe = pipeData.Rigidbody.transform.position;
                pipeData.Rigidbody.useGravity = true;
                pipeData.Rigidbody.AddForce(new Vector3(-pipe.x * force,0,pipe.z), ForceMode.Impulse);
                pipeData.Rigidbody.AddForce(-pipeData.Rigidbody.transform.up * force, ForceMode.Impulse);
                pipeData.Rigidbody.transform.DORotate(rand,1.5f);
            }
        }
    }
}