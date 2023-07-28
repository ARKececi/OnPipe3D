using CameraScripts.Signalable;
using UnityEngine;

namespace LevelScripts.Controllers
{
    public class FinishController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private GameObject finishObj;
        [SerializeField] private Rigidbody finishObjRigidbody;

        #endregion

        #endregion

        public void FinishobjFollow(GameObject player)
        {
            finishObj.transform.position = new Vector3(0,player.transform.position.y,0);
            finishObjRigidbody.AddForce(finishObj.transform.up * 2,ForceMode.Impulse);
            CameraSignalable.Instance.onSetCamera?.Invoke(finishObj);
        }
    }
}