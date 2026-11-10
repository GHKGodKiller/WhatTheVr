using UnityEngine;

public class OutOfBoundsTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Intenta buscar el componente Respawnable en el objeto que tocó el trigger
        Respawnable respawnable = other.GetComponent<Respawnable>();
        
        // Si no lo encuentra, búscalo en toda la jerarquía hacia arriba (para el jugador)
        if (respawnable == null)
        {
            respawnable = other.GetComponentInParent<Respawnable>();
        }

        // Si lo encuentra, ejecuta la función Respawn
        if (respawnable != null)
        {
            respawnable.Respawn();
        }
    }
}