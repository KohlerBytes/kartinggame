using UnityEngine;

namespace KartingCustom.Managers
{
    /// <summary>Cronômetro da corrida com melhor tempo salvo via PlayerPrefs.</summary>
    public class RaceTimer : MonoBehaviour
    {
        private const string BestTimeKey = "KartingCustom_BestTime";

        public float Elapsed { get; private set; }
        public float BestTime { get; private set; }
        public bool Running { get; private set; }

        private void Awake()
        {
            BestTime = PlayerPrefs.GetFloat(BestTimeKey, 0f);
        }

        private void Start() { StartTimer(); }

        private void Update()
        {
            if (Running) Elapsed += Time.deltaTime;
        }

        public void StartTimer()
        {
            Elapsed = 0f;
            Running = true;
        }

        public void StopTimer()
        {
            if (!Running) return;
            Running = false;

            if (BestTime <= 0f || Elapsed < BestTime)
            {
                BestTime = Elapsed;
                PlayerPrefs.SetFloat(BestTimeKey, BestTime);
                PlayerPrefs.Save();
            }
        }

        public static string Format(float seconds)
        {
            int min = (int)(seconds / 60f);
            float sec = seconds % 60f;
            return string.Format("{0:00}:{1:00.00}", min, sec);
        }
    }
}
