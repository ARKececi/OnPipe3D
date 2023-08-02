using System;
using System.Collections.Generic;
using Data.UnityObject;
using Data.ValueObject;
using Enums;
using StubScripts.PipesScripts.ValueData;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

namespace Controllers.PoolController
{
    public class PoolController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private SerializedDictionary<PoolType, PoolData> poolData = new SerializedDictionary<PoolType, PoolData>();
        [SerializeField] private SerializedDictionary<PoolType, PoolChange> poolChanges = new SerializedDictionary<PoolType, PoolChange>();
        [SerializeField] private SerializedDictionary<GameObject, PipeData> pipes = new SerializedDictionary<GameObject, PipeData>();
        [SerializeField] private SerializedDictionary<GameObject, Transform> pipesPosition = new SerializedDictionary<GameObject, Transform>();
        [SerializeField] private GameObject place;

        #endregion

        #region Private Variables

        private SerializedDictionary<GameObject, LocationData> _location = new SerializedDictionary<GameObject, LocationData> ();
        private const string _dataPath = "Data/CD_Pool";
        
        #endregion

        #endregion

        private void Awake()
        {
            poolData = GetWeaponData();
            foreach (var VARIABLE in poolData.Keys)
            {
                poolChanges.Add(VARIABLE,new PoolChange());
            }

            Pooling();
        }

        private SerializedDictionary<PoolType, PoolData> GetWeaponData()
        {
            return Resources.Load<CD_Pool>(_dataPath).PoolDatas;
        }
        
        private void Pooling()
        {
            foreach (var PoolType in poolData.Keys)
            {
                GameObject PoolObj = poolData[PoolType].PoolObj;
                    int PoolCount = poolData[PoolType].PoolCount;
                    for (int i = 0; i < PoolCount; i++)
                    {
                        var poolObj = Instantiate(PoolObj);
                        Listadd(poolObj, PoolType);
                    }
            }
        }
        
        public void Listadd(GameObject poolObj, PoolType poolType)
        {
            poolChanges[poolType].Pool.Add(poolObj);
            poolObj.transform.SetParent(place.transform,true);
            poolObj.transform.position = Vector3.zero;
            poolObj.SetActive(false);
            if (poolChanges[poolType].Use.Contains(poolObj))
            {
                poolChanges[poolType].Use.Remove(poolObj);
            }
        }
        
        public GameObject ListRemove(PoolType poolType)
        {
            if (poolChanges[poolType].Pool.Count != 0)
            {
                GameObject poolObj = poolChanges[poolType].Pool[0];
                poolChanges[poolType].Use.Add(poolObj);
                poolObj.SetActive(true);
                if (poolChanges[poolType].Pool.Contains(poolObj))
                {
                    poolChanges[poolType].Pool.Remove(poolObj);
                }
                return poolObj;
            }
            else return null;
        }

        public void ListPipeAdd(PipeData pipe)
        {
            pipes.Add(pipe.Transform.gameObject,pipe);
            LocationData locationData = new LocationData();
            locationData.Position = pipe.Transform.transform.localPosition;
            locationData.Rotation = pipe.Transform.transform.eulerAngles;
            _location.Add(pipe.Transform.gameObject,locationData);
        }

        public void PipePlacement(GameObject pipe)
        {
            pipes[pipe].Rigidbody.useGravity = false;
            pipes[pipe].Rigidbody.velocity = Vector3.zero;
            pipe.transform.localPosition = _location[pipe].Position;
            pipe.transform.eulerAngles = _location[pipe].Rotation;
            pipe.SetActive(false);
        }

        public void ListPipeRemove(PipeData pipe)
        {
            pipe.Rigidbody.useGravity = false;
            pipes.Remove(pipe.Transform.gameObject);
            _location.Remove(pipe.Transform.gameObject);
        }

        public void Reset()
        {
            foreach (var VARIABLE in pipes.Keys)
            {
                PipePlacement(VARIABLE);
            }
            
            foreach (var VARIABLE in poolChanges.Keys)
            {
                for (int i = 0; i < poolChanges[VARIABLE].Use.Count; i++)
                {
                    if (VARIABLE == PoolType.Stup)
                    {
                        Listadd(poolChanges[VARIABLE].Use[0],PoolType.Stup);   
                    }
                }
            }
        }
    }
}