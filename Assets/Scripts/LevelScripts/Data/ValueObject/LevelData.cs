using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelScripts.Data.ValueObject
{
    [Serializable]
    public class LevelData
    {
        public List<GameObject> LevelRod;
        public int RodSpawnPositionAmount;
    }
}