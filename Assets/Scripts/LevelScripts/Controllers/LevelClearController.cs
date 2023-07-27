using System.Collections.Generic;
using UnityEngine;

namespace LevelScripts.Controllers
{
    public class LevelClearController : MonoBehaviour
    {
        public void ClearLevel(List<GameObject> levelRods)
        {
            foreach (var VARIABLE in levelRods)
            {
                Destroy(VARIABLE.gameObject);
            }
        }
    }
}