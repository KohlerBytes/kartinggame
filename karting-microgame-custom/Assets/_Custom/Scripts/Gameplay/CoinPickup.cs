using UnityEngine;
using KartingCustom.Managers;

namespace KartingCustom.Gameplay
{
    /// <summary>
    /// Moeda coletável. Gira e flutua; ao ser coletada soma pontos no ScoreManager.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class CoinPickup : MonoBehaviour
    {
        [SerializeField] private int points = 10;
        [SerializeField] private float rotationSpeed = 120f;
        [SerializeField] private float bobHeight = 0.25f;
        [SerializeField] private float bobSpeed = 2f;
        [SerializeField] private AudioClip pickupSound;

        private Vector3 _startPos;

        private void Reset()
        {
            GetComponent<Collider>().isTrigger = true;
        }

        private void Start()
        {
            _startPos = transform.position;
        }

        private void Update()
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
            float offset = Mathf.Sin(Time.time * bobSpeed) * bobHeight;
            transform.position = _startPos + Vector3.up * offset;
        }

        private void OnTriggerEnter(Collider other)
        {
            // Só reage a corpos com Rigidbody (o kart)
            if (other.attachedRigidbody == null) return;

            if (ScoreManager.Instance != null)
                ScoreManager.Instance.AddPoints(points);

            if (pickupSound != null)
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);

            Destroy(gameObject);
        }
    }
}
