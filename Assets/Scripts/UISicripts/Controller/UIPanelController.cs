using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UISicripts.Enum;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UISicripts.Controller
{
    public class UIPanelController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private Image finishPanelImage;
        [SerializeField] private GameObject scorePanel;
        [SerializeField] private List<TextMeshProUGUI> scoreTextMeshPro = new List<TextMeshProUGUI>();
        [SerializeField] private List<TextMeshProUGUI> levelTextMeshPro = new List<TextMeshProUGUI>();
        [SerializeField] private TextMeshProUGUI levelComplated;
        [SerializeField] private TextMeshProUGUI bestScore;
        [SerializeField] private List<TextMeshProUGUI> startTextMeshPro = new List<TextMeshProUGUI>();
        [SerializeField] private Color color;
        [SerializeField] private float timer;

        #endregion

        #region Private Variables

        private int _score;
        private int _complated;

        #endregion

        #endregion
        
        private void Awake()
        {
            bestScore.text = "BEST " + GetBestScore();
        }
        
        private int GetBestScore()
        {
            if (!ES3.FileExists()) return 0;
            return ES3.KeyExists("BestScore") ? ES3.Load<int>("BestScore") : 0;
        }

        public void PanelAction(UIPanel panelParam )
        {
            switch (panelParam)
            {   
                case UIPanel.ScorePanel :
                    scorePanel.transform.DOMoveX(0f, .2f);
                    break;
                case UIPanel.FinishPanel:
                    finishPanelImage.DOColor(new Color(0, 0, 0, color.a), timer).OnComplete(()=>
                    {
                        levelTextMeshPro[0].DOColor(Color.white, timer).OnComplete(() =>
                        {
                            levelComplated.DOColor(Color.white, timer).OnComplete(() =>
                            {
                                scoreTextMeshPro[0].DOColor(Color.white, timer).OnComplete(() =>
                                {
                                    bestScore.DOColor(Color.white, timer);
                                });
                            });
                        });
                    });
                    break;
                case UIPanel.StartPanel :
                    foreach (var VARIABLE in startTextMeshPro)
                    {
                        VARIABLE.DOColor(Color.white, timer);
                    }
                    break;
            }
        }

        public void PanelsReset(UIPanel panelParam)
        {
            switch (panelParam)
            {
                case UIPanel.ScorePanel :
                    scorePanel.transform.DOKill(); scorePanel.transform.DOMoveX(-800f, .2f);
                    break;
                case UIPanel.FinishPanel :
                    finishPanelImage.DOKill(); finishPanelImage.color = new Color(0, 0, 0, 0);
                    scoreTextMeshPro[0].DOKill(); scoreTextMeshPro[0].color = new Color(1, 1, 1, 0);
                    levelComplated.DOKill(); levelComplated.color = new(1, 1, 1, 0);
                    levelTextMeshPro[0].DOKill(); levelTextMeshPro[0].color = new Color(1, 1, 1, 0);
                    bestScore.DOKill(); bestScore.color = new Color(1, 1, 1, 0);
                    break;
                case UIPanel.StartPanel :
                    foreach (var VARIABLE in startTextMeshPro)
                    {
                        VARIABLE.DOColor(new Color(1,1,1,0), timer);
                    }
                    break;
            }
        }
        
        public void LevelSet(int level)
        {
            foreach (var VARIABLE in levelTextMeshPro)
            {
                VARIABLE.text = "LEVEL " + level;
            }
        }

        public void ScoreSet(int score)
        {
            _complated += score;
            _score += score;
            foreach (var VARIABLE in scoreTextMeshPro)
            {
                VARIABLE.text = _score.ToString();
            }
        }

        public void LevelComplated(bool final)
        {
            if (final) levelComplated.text = "CLEARED";
            else levelComplated.text = "COMPLATED " + _complated + "%";
            _complated = 0;
        }

        public int BestScore()
        {
            if (_score > GetBestScore())
            {
                bestScore.text = "BEST " + _score;
                return _score;
            }
            else return GetBestScore();
        }

        public void ScoreReset()
        {
            _score = 0;
            ScoreSet(_score);
        }
    }
}