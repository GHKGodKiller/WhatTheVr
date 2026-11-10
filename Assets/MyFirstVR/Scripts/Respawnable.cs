using UnityEngine;

public class Respawnable : MonoBehaviour
{
    [Header("Configuración Específica")]
    [Tooltip("Marca esta casilla SOLO en el objeto del jugador (Camera Rig)")]
    public bool isPlayer = false;
    
    [Tooltip("Coordenadas exactas a donde regresará el jugador al caer")]
    public Vector3 playerSafePosition = new Vector3(0, 0, 0);

    private Vector3 startPosition;
    private Quaternion startRotation;
    private Rigidbody rb;

    private void Awake()
    {
        // Guarda la posición original (útil para las pelotas y pinos)
        startPosition = transform.position;
        startRotation = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    [ContextMenu("Reaparecer Objeto")]
    public void Respawn()
    {
        // Apaga el Character Controller temporalmente para permitir el teletransporte
        CharacterController cc = GetComponentInChildren<CharacterController>();
        if (cc != null) cc.enabled = false; 

        // Si el objeto es el jugador, lo manda a la coordenada fija (ej. 0, 0, 0)
        if (isPlayer)
        {
            transform.position = playerSafePosition;
        }
        // Si no es el jugador (pelotas, etc.), regresan a su punto guardado
        else
        {
            transform.position = startPosition;
            transform.rotation = startRotation;
        }

        // Resetea la inercia de caída si es un objeto físico
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        // Vuelve a encender el Character Controller en la nueva posición
        if (cc != null) cc.enabled = true; 
    }
}