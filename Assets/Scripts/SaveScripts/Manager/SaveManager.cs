using SaveScripts.Signalable;
using SaveScripts.Struck;
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
                LevelCount = 0
            });
        }
        
        private void OnSaveGame(SaveDataParams saveDataParams)
        {
            ES3.Save("LevelCount", saveDataParams.LevelCount);
        }
    }
}