using UnityEngine;

public class HoleDetector : MonoBehaviour
{
    [Header("Efectos (Opcionales)")]
    [SerializeField] private ParticleSystem winParticles;
    [SerializeField] private AudioSource winAudio;

    [Header("Configuración")]
    [SerializeField] private string ballTag = "Ball";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ballTag) || other.name.Contains("GolfBall"))
        {
            Debug.Log("⛳ ¡HOLE IN ONE! La pelota ha entrado al hoyo.");

            if (winParticles != null)
            {
                winParticles.Play();
            }

            if (winAudio != null)
            {
                winAudio.Play();
            }
        }
    }
}