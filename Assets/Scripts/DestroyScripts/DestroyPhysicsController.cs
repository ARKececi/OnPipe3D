using System;
using UnityEngine;

namespace DestroyScripts
{
    public class DestroyPhysicsController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ball"))
            {
                other.gameObject.SetActive(false);
            }
        }
    }
}