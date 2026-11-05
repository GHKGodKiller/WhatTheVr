using UnityEngine;

public class BowlingReset : MonoBehaviour
{
    [System.Serializable]
    private struct PinData
    {
        public Transform pinTransform;
        public Vector3 initialPosition;
        public Quaternion initialRotation;
        public Rigidbody pinRigidbody;
    }

    [Header("Arrastra aquí los 10 pinos de boliche")]
    [SerializeField] private Transform[] pins;

    private PinData[] initialPinData;

    private void Start()
    {
        if (pins == null || pins.Length == 0) return;

        // Guardar posiciones y rotaciones iniciales del triángulo de pinos
        initialPinData = new PinData[pins.Length];
        for (int i = 0; i < pins.Length; i++)
        {
            if (pins[i] != null)
            {
                initialPinData[i].pinTransform = pins[i];
                initialPinData[i].initialPosition = pins[i].position;
                initialPinData[i].initialRotation = pins[i].rotation;
                initialPinData[i].pinRigidbody = pins[i].GetComponent<Rigidbody>();
            }
        }
    }

    [ContextMenu("Reiniciar Pinos")]
    public void ResetPins()
    {
        if (initialPinData == null) return;

        foreach (var pinData in initialPinData)
        {
            if (pinData.pinTransform != null)
            {
                pinData.pinTransform.position = pinData.initialPosition;
                pinData.pinTransform.rotation = pinData.initialRotation;

                if (pinData.pinRigidbody != null)
                {
                    pinData.pinRigidbody.linearVelocity = Vector3.zero;
                    pinData.pinRigidbody.angularVelocity = Vector3.zero;
                }
            }
        }
        

        Debug.Log("🎳 Pinos de boliche reiniciados a su posición inicial.");
    }
private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Ball"))
    {
        // Espera 6 segundos a que los pinos caigan y luego los reacomoda
        Invoke(nameof(ResetPins), 6f);
    }
}
    private void OnTriggerEnter(Collider other)
    {
        // Si el jugador entra a una zona de botón o toca el trigger con los mandos/manos VR
        if (other.CompareTag("Player") || other.name.Contains("Hand") || other.name.Contains("Controller"))
        {
            ResetPins();
        }
    }
}