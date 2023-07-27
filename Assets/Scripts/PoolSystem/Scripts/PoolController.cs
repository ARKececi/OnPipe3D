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

        private bool _notFirstPooling;

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
            return Resources.Load<CD_Pool>("Data/CD_Pool").PoolDatas;
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
        }

        public void PipePlacement(GameObject pipe)
        {
            pipes[pipe].Rigidbody.useGravity = false;
            pipes[pipe].Rigidbody.velocity = Vector3.zero;
            pipe.transform.position = pipes[pipe].Transform.position;
            pipe.transform.rotation = pipes[pipe].Transform.rotation;
        }
    }
}