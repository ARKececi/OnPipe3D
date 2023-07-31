using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UISicripts.Enum;
using UnityEngine;
using UnityEngine.Rendering;
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
        [SerializeField] private TextMeshProUGUI levelComplate;
        [SerializeField] private Color color;
        [SerializeField] private float timer;

        #endregion

        #region Private Variables

        private int _score;

        #endregion

        #endregion
        
        private void Awake()
        {
            
        }

        public void PanelAction(UIPanel panelParam )
        {
            switch (panelParam)
            {   
                case UIPanel.ScorePanel :
                    //scorePanel.transform.DOMoveX(0f, .2f);
                    break;
                case UIPanel.FinishPanel:
                    scorePanel.transform.DOMoveX(-800f, timer);
                    finishPanelImage.DOColor(new Color(0, 0, 0, color.a), timer).OnComplete(()=>
                    {
                        levelTextMeshPro[0].DOColor(Color.white, timer).OnComplete(() =>
                        {
                            levelComplate.DOColor(Color.white, timer).OnComplete(() =>
                            {
                                scoreTextMeshPro[0].DOColor(Color.white, timer);
                            });
                        });
                    });
                    break;
            }
        }

        public void PanelsReset(UIPanel panelParam)
        {
            switch (panelParam)
            {
                case UIPanel.ScorePanel :
                    scorePanel.transform.DOMoveX(-800f, .2f);
                    
                    break;
                case UIPanel.FinishPanel :
                    scorePanel.transform.DOMoveX(0f, .2f);
                    finishPanelImage.color = new Color(0, 0, 0, 0);
                    scoreTextMeshPro[0].color = new Color(1, 1, 1, 0);
                    levelComplate.color = new(1, 1, 1, 0);
                    levelTextMeshPro[0].color = new Color(1, 1, 1, 0);
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

        public void ScoreText(int score)
        {
            _score += score;
            foreach (var VARIABLE in scoreTextMeshPro)
            {
                VARIABLE.text = _score.ToString();
            }
        }
    }
}