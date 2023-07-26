using System;
using UnityEngine;

namespace PlayerScripts.Data.ValueObject
{
    [Serializable]
    public class PlayerData
    {
        public float Speed = 1;
        public float ScaleTimer = .001f;
        public float Amount = 0.1f;
    }
}