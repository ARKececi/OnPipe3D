using System;
using System.Collections.Generic;
using CameraScripts.Signalable;
using LevelScripts.Controllers;
using LevelScripts.Data.UnityObject;
using LevelScripts.Data.ValueObject;
using LevelScripts.Signalable;
using PlayerScripts.Signalable;
using SaveScripts.Signalable;
using UISicripts.Signalable;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

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
        [SerializeField] private int levelRodCount;

        #endregion

        #region Private Variables
        
        private List<GameObject> levelRods = new List<GameObject>();
        private int _levelCount, _rodCount, _levelID, _spawnDotPostionY, _startRodCount;
        private bool _isFirstTimeTouchTaken;
        private const string _dataPath = "Data/CD_LevelData";
        private const string _savePath = "LevelCount";

        #endregion

        #endregion
        
        private void Awake()
        {
            _rodCount++;
            _levelData = GetLevelData();
            _levelID = GetActiveLevel();
            _levelCount = _levelID;
            levelRods = LevelAdd();
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
            LevelSignalable.Instance.onSaveLevel += OnSaveLevel;
        }

        private void UnsubscribeEvents()
        {
            LevelSignalable.Instance.onNextRod -= OnNextRod;
            LevelSignalable.Instance.onGameStart -= OnGameStart;
            LevelSignalable.Instance.onNextLevel -= OnNextLevel;
            LevelSignalable.Instance.onReset -= OnReset;
            LevelSignalable.Instance.onSaveLevel -= OnSaveLevel;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        #endregion

        private SerializedDictionary<int, LevelData> GetLevelData()
        {
            return Resources.Load<CD_LevelData>(_dataPath).LevelData;
        }
        
        private int GetActiveLevel()
        {
            if (!ES3.FileExists()) return 0;
            return ES3.KeyExists(_savePath) ? ES3.Load<int>(_savePath) : 0;
        }

        public int OnSaveLevel(){ return _levelCount; }

        private List<GameObject> LevelAdd()
        {
            _levelID %= _levelData.Count;
            _levelCount++;
            UISignalable.Instance.onLevelSet?.Invoke(_levelCount);
            return levelLoader.LoaderLevel(_levelData[_levelID], levelHolder.transform);
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
            if (_startRodCount < levelRodCount)
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
            LevelClear(levelRods);
            levelRods = LevelAdd();
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