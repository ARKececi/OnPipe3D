using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data.ValueObject
{
    [Serializable]
    public class PoolChange
    {
        public List<GameObject> Pool = new List<GameObject>();
        public List<GameObject> Use = new List<GameObject>();
    }
}