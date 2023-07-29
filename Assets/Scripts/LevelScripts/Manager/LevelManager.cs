using System;
using System.Collections.Generic;
using CameraScripts.Signalable;
using LevelScripts.Controllers;
using LevelScripts.Data.UnityObject;
using LevelScripts.Data.ValueObject;
using LevelScripts.Signalable;
using PlayerScripts.Signalable;
using UISicripts.Signalable;
using UnityEngine;
using UnityEngine.Rendering;

namespace LevelScripts.Manager
{
    public class LevelManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private SerializedDictionary<int, LevelData> _levelData =new SerializedDictionary<int, LevelData>();
        [SerializeField] private GameObject levelHolder;
        [SerializeField] private LevelLoaderController levelLoader;
        [SerializeField] private LevelClearController clearlevel;
        [SerializeField] private GameObject finish;

        #endregion

        #region Private Variables
        
        [SerializeField] private List<GameObject> levelRods = new List<GameObject>();
        private int _levelCount, _rodCount, _levelID, _spawnDotPostionY, _startRodCount;
        [SerializeField]private bool _isFirstTimeTouchTaken;

        #endregion

        #endregion
        
        private void Awake()
        {
            _rodCount++;
            _levelData = GetLevelData();
            levelRods = LevelAdd(_levelID);
            levelRods[0].SetActive(true);
        }
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            LevelSignalable.Instance.onNextRod += OnNextRod;
            LevelSignalable.Instance.onGameStart += OnGameStart;
            LevelSignalable.Instance.onNextLevel += OnNextLevel;
            LevelSignalable.Instance.onReset += OnReset;
        }

        private void UnsubscribeEvents()
        {
            LevelSignalable.Instance.onNextRod -= OnNextRod;
            LevelSignalable.Instance.onGameStart -= OnGameStart;
            LevelSignalable.Instance.onNextLevel -= OnNextLevel;
            LevelSignalable.Instance.onReset -= OnReset;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        #endregion

        private SerializedDictionary<int, LevelData> GetLevelData()
        {
            return Resources.Load<CD_LevelData>("Data/CD_LevelData").LevelData;
        }

        private List<GameObject> LevelAdd(int levelID)
        {
            return levelLoader.LoaderLevel(_levelData[levelID], levelHolder.transform);
        }

        private void LevelClear(List<GameObject> levelRods)
        {
            clearlevel.ClearLevel(levelRods);
            for (int i = 0; i < levelRods.Count; i++)
            {
                levelRods.Remove(levelRods[0]);
            }
        }

        private void OnGameStart()
        {
            _isFirstTimeTouchTaken = true;
        }

        private void OnNextRod()
        {
            if (_startRodCount < 4)
            {
                GameObject levelrod = levelRods[_rodCount % levelRods.Count];
                levelrod.SetActive(false);
                _spawnDotPostionY += _levelData[_levelID].RodSpawnPositionAmount;
                levelrod.transform.position = new Vector3(0, _spawnDotPostionY , 0);
                levelrod.SetActive(true);
                _rodCount++;
                if (_isFirstTimeTouchTaken) _startRodCount++;
            }
            else
            {
                _spawnDotPostionY += _levelData[_levelID].RodSpawnPositionAmount;
                finish.transform.position = new Vector3(0, _spawnDotPostionY , 0);
                finish.SetActive(true);
            }
        }

        private void OnNextLevel()
        {
            _levelID++;
            _levelID %= _levelData.Count;
            LevelClear(levelRods);
            levelRods = LevelAdd(_levelID);
            OnReset();
        }

        private void RodActiveFalse()
        {
            foreach (var VARIABLE in levelRods)
            {
                VARIABLE.SetActive(false);
            }
        }

        private void OnReset()
        {
            RodActiveFalse();
            _isFirstTimeTouchTaken = false;
            _spawnDotPostionY = 0;
            _startRodCount = 0;
            _rodCount = 1;
            levelRods[0].transform.position = Vector3.zero;
            levelRods[0].SetActive(true);
            finish.SetActive(false);
        }
    }
}