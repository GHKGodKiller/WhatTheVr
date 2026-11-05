using UnityEngine;

public class PatrullaVoladora : MonoBehaviour
{
    [Header("Ruta de Vuelo")]
    public Transform[] puntosRuta; // Arrastra aquí tus puntos desde el editor
    public float velocidad = 15f;
    public float velocidadGiro = 5f;
    public float distanciaCambio = 2f;

    private int indiceActual = 0;

    void Update()
    {
        if (puntosRuta.Length == 0) return;

        // 1. Obtener la dirección hacia el siguiente punto
        Vector3 direccion = puntosRuta[indiceActual].position - transform.position;

        // 2. Rotar suavemente hacia el objetivo
        if (direccion != Vector3.zero)
        {
            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, velocidadGiro * Time.deltaTime);
        }

        // 3. Moverse hacia adelante
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);

        // 4. ¿Llegamos al punto? Pasar al siguiente
        if (Vector3.Distance(transform.position, puntosRuta[indiceActual].position) < distanciaCambio)
        {
            indiceActual = (indiceActual + 1) % puntosRuta.Length; // Ciclo infinito por los puntos
        }
    }
}