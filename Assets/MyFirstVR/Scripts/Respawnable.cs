using UnityEngine;

public class Respawnable : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Rigidbody rb;

    private void Awake()
    {
        // Guardamos la posición y rotación exactas donde inicia el objeto/jugador
        startPosition = transform.position;
        startRotation = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    [ContextMenu("Reaparecer Objeto")]
    public void Respawn()
    {
        // 1. Si el objeto es el jugador (tiene CharacterController), lo apagamos un instante
        CharacterController cc = GetComponent<CharacterController>();
        if (cc != null)
        {
            cc.enabled = false; 
        }

        // 2. Teletransportamos el objeto a su posición y rotación inicial
        transform.position = startPosition;
        transform.rotation = startRotation;

        // 3. Si el objeto tiene físicas (como pelotas o el palo de golf), frenamos su caída
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        // 4. Si era el jugador, volvemos a encender su controlador de movimiento
        if (cc != null)
        {
            cc.enabled = true; 
        }
    }
}