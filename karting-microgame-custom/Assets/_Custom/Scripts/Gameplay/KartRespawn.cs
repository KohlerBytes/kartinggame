using UnityEngine;

namespace KartingCustom.Gameplay
{
    /// <summary>
    /// Recoloca o kart na pista caso ele caia do mapa ou capote.
    /// Pressione R para resetar manualmente.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class KartRespawn : MonoBehaviour
    {
        [SerializeField] private float fallLimitY = -20f;
        [SerializeField] private KeyCode resetKey = KeyCode.R;

        private Rigidbody _body;
        private Vector3 _lastSafePosition;
        private Quaternion _lastSafeRotation;
        private float _safeTimer;

        private void Awake()
        {
            _body = GetComponent<Rigidbody>();
            _lastSafePosition = transform.position;
            _lastSafeRotation = transform.rotation;
        }

        private void Update()
        {
            // Salva uma posição segura a cada 2 segundos, se o kart está de pé
            _safeTimer += Time.deltaTime;
            if (_safeTimer >= 2f && Vector3.Dot(transform.up, Vector3.up) > 0.7f)
            {
                _lastSafePosition = transform.position;
                _lastSafeRotation = Quaternion.Euler(0f, transform.eulerAngles.y, 0f);
                _safeTimer = 0f;
            }

            if (transform.position.y < fallLimitY || Input.GetKeyDown(resetKey))
                Respawn();
        }

        private void Respawn()
        {
            _body.velocity = Vector3.zero;
            _body.angularVelocity = Vector3.zero;
            transform.SetPositionAndRotation(_lastSafePosition + Vector3.up * 1f, _lastSafeRotation);
        }
    }
}
