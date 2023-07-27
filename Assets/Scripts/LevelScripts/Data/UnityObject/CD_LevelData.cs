using LevelScripts.Data.ValueObject;
using UnityEngine;
using UnityEngine.Rendering;

namespace LevelScripts.Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_LevelData", menuName = "Data/CD_LevelData", order = 0)]
    public class CD_LevelData : ScriptableObject
    {
        public SerializedDictionary<int ,LevelData> LevelData;
    }
}