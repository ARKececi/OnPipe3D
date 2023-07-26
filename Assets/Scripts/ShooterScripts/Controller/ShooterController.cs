using System.Collections.Generic;
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
        
        public void Shooter(List<Rigidbody> pipes)
        {
            foreach (var varıable in pipes)
            {
                varıable.useGravity = true;
                varıable.AddForce(varıable.transform.right * force, ForceMode.Impulse);
                varıable.AddForce(varıable.transform.up * force, ForceMode.Impulse);
            }
        }
    }
}