using LevelScripts.Signalable;
using SaveScripts.Signalable;
using SaveScripts.Struck;
using UISicripts.Signalable;
using UnityEngine;

namespace SaveScripts
{
    public class SaveManager : MonoBehaviour
    {
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            SaveSignalable.Instance.onSave += OnSave;
        }

        private void UnsubscribeEvents()
        {
            SaveSignalable.Instance.onSave -= OnSave;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        #endregion
        
        private void OnSave()
        {
            OnSaveGame(new SaveDataParams()
            {
                LevelCount = (int)LevelSignalable.Instance.onSaveLevel?.Invoke(),
                BestScore = (int)UISignalable.Instance.onBestScore?.Invoke()
            });
        }
        
        private void OnSaveGame(SaveDataParams saveDataParams)
        {
            ES3.Save("LevelCount", saveDataParams.LevelCount);
            ES3.Save("BestScore", saveDataParams.BestScore);
        }
    }
}