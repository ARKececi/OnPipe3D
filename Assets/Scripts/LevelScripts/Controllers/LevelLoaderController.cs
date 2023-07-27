using System.Collections.Generic;
using LevelScripts.Data.UnityObject;
using LevelScripts.Data.ValueObject;
using UnityEngine;

namespace LevelScripts.Controllers
{
    public class LevelLoaderController : MonoBehaviour
    {
        #region Self Variables

        #region Privarte Variables

        private List<GameObject> _levelRods = new List<GameObject>();

        #endregion

        #endregion

        public List<GameObject> LoaderLevel(LevelData level, Transform spawnDot)
        {
            foreach (var VARIABLE in level.LevelRod)
            {
                GameObject levelRod = Instantiate(VARIABLE, spawnDot);
                _levelRods.Add(levelRod); 
                levelRod.SetActive(false);
            }
            return _levelRods;
        }
    }
}