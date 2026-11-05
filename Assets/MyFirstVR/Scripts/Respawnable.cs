using UnityEngine;

public class Respawnable : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Rigidbody rb;

    private void Awake()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    [ContextMenu("Reaparecer Objeto")]
    public void Respawn()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;

        if (rb != null)
        {
            // Cancela la velocidad acumulada por la caída
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}