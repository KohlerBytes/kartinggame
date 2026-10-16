using UnityEngine;
using KartingCustom.Managers;

namespace KartingCustom.UI
{
    /// <summary>
    /// HUD simples via OnGUI (sem dependências de Canvas/TextMeshPro).
    /// Mostra pontuação, tempo atual e melhor tempo.
    /// </summary>
    public class HudDisplay : MonoBehaviour
    {
        [SerializeField] private RaceTimer raceTimer;
        [SerializeField] private int fontSize = 22;

        private GUIStyle _style;

        private void OnGUI()
        {
            if (_style == null)
            {
                _style = new GUIStyle(GUI.skin.label)
                {
                    fontSize = fontSize,
                    fontStyle = FontStyle.Bold
                };
                _style.normal.textColor = Color.white;
            }

            int score = ScoreManager.Instance != null ? ScoreManager.Instance.Score : 0;
            GUI.Label(new Rect(20, 20, 400, 40), "Pontos: " + score, _style);

            if (raceTimer != null)
            {
                GUI.Label(new Rect(20, 55, 400, 40), "Tempo: " + RaceTimer.Format(raceTimer.Elapsed), _style);
                if (raceTimer.BestTime > 0f)
                    GUI.Label(new Rect(20, 90, 400, 40), "Recorde: " + RaceTimer.Format(raceTimer.BestTime), _style);
            }
        }
    }
}
