using System.Collections.Generic;
using UISicripts.Enum;
using UnityEngine;

namespace UISicripts.Controller
{
    public class UIPanelController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private List<GameObject> panels;

        #endregion

        #endregion

        public void OpenPanel(UIPanel panelParam )
        {
            panels[(int) panelParam].SetActive(true);
        }

        public void ClosePanel(UIPanel panelParam)
        {
            panels[(int) panelParam].SetActive(false);
        }
    }
}