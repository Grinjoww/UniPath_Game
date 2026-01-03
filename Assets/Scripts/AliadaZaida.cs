using UnityEngine;

public class AliadaZaida : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 1. Verificamos si lo que entró es el Jugador (o parte de él)
        // Usamos GetComponentInParent por si chocas con el brazo o el pie
        MovimientoJugador jaime = other.GetComponentInParent<MovimientoJugador>();

        if (jaime != null)
        {
            // 2. Le decimos a Jaime que se calme
            jaime.Calmarse();


            // 3. (Opcional) Desaparecemos a Zaida para que sea un ítem de un solo uso
            // Destroy(gameObject); 
        }
    }
}