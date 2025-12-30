using UnityEngine;

public class AliadaZaida : MonoBehaviour
{
    public SistemaVerguenza managerVerguenza; // Conexión con la barra morada

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("💙 ¡Encontraste a Zaida! (Inmunidad Activada)");

            // Activamos el truco en el otro script
            managerVerguenza.ActivarModoZaida();

            // Opcional: Aquí podrías poner un diálogo flotante luego

            // Destruimos este script/objeto o lo apagamos para que no se repita
            // gameObject.SetActive(false); // Si quieres que desaparezca visualmente
            Destroy(this); // Solo borramos el script, el cilindro se queda
        }
    }
}