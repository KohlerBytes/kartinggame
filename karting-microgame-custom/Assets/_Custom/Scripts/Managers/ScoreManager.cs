using System;
using UnityEngine;

namespace KartingCustom.Managers
{
    /// <summary>Singleton simples que guarda a pontuação da partida.</summary>
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }

        public int Score { get; private set; }
        public event Action<int> OnScoreChanged;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        public void AddPoints(int amount)
        {
            Score += amount;
            if (OnScoreChanged != null) OnScoreChanged(Score);
        }

        public void ResetScore()
        {
            Score = 0;
            if (OnScoreChanged != null) OnScoreChanged(Score);
        }
    }
}
