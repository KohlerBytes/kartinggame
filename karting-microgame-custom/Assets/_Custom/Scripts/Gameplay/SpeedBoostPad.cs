using UnityEngine;

namespace KartingCustom.Gameplay
{
    /// <summary>
    /// Pad de turbo: ao ser tocado por um kart, aplica um impulso para frente.
    /// Adicione a um objeto com Collider marcado como "Is Trigger".
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class SpeedBoostPad : MonoBehaviour
    {
        [Header("Configuração do Turbo")]
        [SerializeField] private float boostForce = 12f;
        [SerializeField] private float cooldown = 1.5f;
        [SerializeField] private AudioClip boostSound;

        private float _nextAllowedTime;

        private void Reset()
        {
            GetComponent<Collider>().isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (Time.time < _nextAllowedTime) return;

            Rigidbody kartBody = other.attachedRigidbody;
            if (kartBody == null || kartBody.isKinematic) return;

            // Impulso na direção em que o kart está virado
            kartBody.AddForce(kartBody.transform.forward * boostForce, ForceMode.VelocityChange);
            _nextAllowedTime = Time.time + cooldown;

            if (boostSound != null)
                AudioSource.PlayClipAtPoint(boostSound, transform.position);
        }
    }
}
